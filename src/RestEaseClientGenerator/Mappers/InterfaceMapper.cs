using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Constants;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Types.Internal;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Mappers;

internal class InterfaceMapper : BaseMapper
{
    private readonly SchemaMapper _schemaMapper;

    public InterfaceMapper(GeneratorSettings settings, SchemaMapper schemaMapper) : base(settings)
    {
        _schemaMapper = schemaMapper;
    }

    public RestEaseInterface Map(OpenApiDocument openApiDocument, string? directory)
    {
        string name = Settings.ApiName.ToValidIdentifier(CasingType.Pascal);
        string interfaceName = $"I{name}Api";

        var @interface = new RestEaseInterface
        (
            openApiDocument,
            interfaceName,
            Settings.Namespace,
            openApiDocument.Info?.Description ?? name
        );

        foreach (var path in openApiDocument.Paths)
        {
            MapPath(@interface, path.Key, path.Value, directory);
        }

        var security = new SecurityMapper(Settings).Map(openApiDocument);
        if (security != null && Settings.PreferredSecurityDefinitionType != SecurityDefinitionType.None)
        {
            var header = security.Definitions.FirstOrDefault(sd => sd.Type == SecurityDefinitionType.Header);
            var query = security.Definitions.FirstOrDefault(sd => sd.Type == SecurityDefinitionType.Query);

            if (header != null &&
                Settings.PreferredSecurityDefinitionType is SecurityDefinitionType.Automatic or SecurityDefinitionType.Header)
            {
                @interface.VariableHeaders.Add(new RestEaseInterfaceHeader(header.IdentifierName, header.Name));
            }
            else if (query != null &&
                     (Settings.PreferredSecurityDefinitionType == SecurityDefinitionType.Automatic || Settings.PreferredSecurityDefinitionType == SecurityDefinitionType.Query))
            {
                @interface.ConstantQueryParameters.Add(new RestEaseInterfaceQueryParameter
                {
                    Name = query.Name,
                    IdentifierWithType = new PropertyDto("string", query.IdentifierName)
                });
            }
        }

        // Select all common optional and mandatory headers from all methods
        if (Settings.DefineAllMethodHeadersOnInterface)
        {
            var headerParameters = @interface.Methods
                .SelectMany(m => m.RestEaseMethod.Parameters.Where(p => p.ParameterLocation == ParameterLocation.Header))
                .Distinct()
                .ToList();

            foreach (var parameter in headerParameters)
            {
                foreach (var method in @interface.Methods)
                {
                    method.RestEaseMethod.Parameters = method.RestEaseMethod.Parameters.Where(p => p != parameter).ToList();
                }

                if (@interface.VariableHeaders.All(v => v.Name != parameter.Identifier))
                {
                    @interface.VariableHeaders.Add(new RestEaseInterfaceHeader(parameter.Identifier, parameter.ValidIdentifier));
                }
            }
        }

        if (!Settings.DefineSharedMethodQueryParametersOnInterface)
        {
            return @interface;
        }

        var groupings = @interface.Methods
            .SelectMany(md => md.RestEaseMethod.Parameters.Where(p => p.ParameterLocation == ParameterLocation.Query))
            .GroupBy(x => x.IdentifierWithRestEase)
            .ToList();

        foreach (var grouping in groupings)
        {
            foreach (var parameter in grouping)
            {
                if (@interface.Methods.All(m => m.RestEaseMethod.Parameters.Select(p => p.IdentifierWithRestEase).Contains(grouping.Key)))
                {
                    if (!@interface.ConstantQueryParameters.Select(cqp => cqp.Name).Contains(parameter.Identifier.ToPascalCase()))
                    {
                        @interface.ConstantQueryParameters.Add(new RestEaseInterfaceQueryParameter
                        {
                            Name = parameter.Identifier,
                            IdentifierWithType = parameter.IdentifierWithTypePascalCase
                        });
                    }

                    // For all method: remove this shared query parameters from parameters and from summary and update extension methods
                    foreach (var method in @interface.Methods)
                    {
                        method.RestEaseMethod.Parameters = method.RestEaseMethod.Parameters.Where(p => p.IdentifierWithRestEase != parameter.IdentifierWithRestEase).ToList();
                        method.SummaryParameters = method.SummaryParameters.Where(p => p.IdentifierWithRestEase != parameter.IdentifierWithRestEase).ToList();
                        if (method.ExtensionMethodDetails != null)
                        {
                            method.ExtensionMethodDetails.RestEaseMethod.Parameters = method.ExtensionMethodDetails.RestEaseMethod.Parameters.Where(p => p.IdentifierWithRestEase != parameter.IdentifierWithRestEase).ToList();
                            method.ExtensionMethodDetails.SummaryParameters = method.ExtensionMethodDetails.SummaryParameters.Where(p => p.IdentifierWithRestEase != parameter.IdentifierWithRestEase).ToList();
                        }
                    }
                }
            }
        }

        return @interface;
    }

    private void MapPath(RestEaseInterface @interface, string path, OpenApiPathItem pathItem, string? directory)
    {
        foreach (var restEaseInterfaceMethodDetails in pathItem.Operations.Select(o => MapOperationToMappingModel(@interface, path, o.Key.ToString(), o.Value, directory)))
        {
            @interface.Methods.Add(restEaseInterfaceMethodDetails);
        }
    }

    private RestEaseInterfaceMethodDetails MapOperationToMappingModel(RestEaseInterface @interface, string path, string httpMethod, OpenApiOperation operation, string? directory)
    {
        string methodRestEaseForAnnotation = httpMethod.ToPascalCase();

        string methodRestEaseMethodName = GeneratedRestEaseMethodName(path, operation, methodRestEaseForAnnotation);

        var parameters = new ParametersMapper(@interface, Settings, directory).Map(operation);

        var headerParameterList = parameters
            .Where(p => p.In == ParameterLocation.Header && p.Schema.GetSchemaType() != SchemaType.Object)
            .Select(p => BuildValidParameter(@interface, p.Name, p.Schema, p.Required, p.Description, p.In, Array.Empty<string>(), directory))
            .ToList();

        var pathParameterNames = RegexUtils.GetParameterNamesFromPath(path).ToList();
        var pathParameterList = parameters
            .Where(p => p.In == ParameterLocation.Path && p.Schema.GetSchemaType() != SchemaType.Object)
            .Select(p => BuildValidParameter(@interface, p.Name, p.Schema, p.Required, p.Description, p.In, Array.Empty<string>(), directory))
            .OrderBy(p => pathParameterNames.IndexOf(p.Identifier))
            .ToList();

        var queryParameterList = parameters
            .Where(p => p.In == ParameterLocation.Query && p.Schema.GetSchemaType() != SchemaType.Object)
            .Select(p => BuildValidParameter(@interface, p.Name, p.Schema, p.Required, p.Description, p.In, Array.Empty<string>(), directory))
            .ToList();

        var extensionMethodParameterList = new List<RestEaseParameter>();
        var bodyParameterList = new List<RestEaseParameter>();

        var requestDetails = operation.RequestBody != null
            ? MapRequest(@interface, operation, bodyParameterList, extensionMethodParameterList, directory)
            : null;

        var headers = new List<string>();
        if (requestDetails != null)
        {
            if (requestDetails.DetectedContentType != null)
            {
                headers.Add($"[Header(\"{HttpKnownHeaderNames.ContentType}\", \"{requestDetails.DetectedContentType.GetDescription()}\")]");
            }
            else if (requestDetails.ContentTypes?.Count > 1)
            {
                headerParameterList.Add(new RestEaseParameter
                {
                    Required = true,
                    Summary = "The Content-Type",
                    ValidIdentifier = "contentType",
                    IdentifierRestEasePrefix = $"[Header(\"{HttpKnownHeaderNames.ContentType}\")]",
                    IdentifierWithType = new PropertyDto("string", "contentType"),
                    IsSpecial = false,
                    SchemaFormat = SchemaFormat.Undefined,
                    SchemaType = SchemaType.String
                });
            }
        }

        var methodParameterList = headerParameterList
            .Union(pathParameterList)
            .Union(bodyParameterList)
            .Union(queryParameterList)
            .OrderByDescending(p => p.Required)
            .ToList();

        var returnType = MapResponse(@interface, operation.Responses, methodRestEaseMethodName, directory);

        var method = new RestEaseInterfaceMethodDetails
        {
            Headers = headers,
            Summary = operation.Summary ?? $"{methodRestEaseMethodName} ({path})",
            SummaryParameters = methodParameterList.Select(mp => new RestEaseSummaryParameter
            {
                ValidIdentifier = mp.ValidIdentifier,
                IdentifierWithRestEase = mp.IdentifierWithRestEase,
                Summary = mp.Summary
            }).ToList(),
            RestEaseAttribute = new(methodRestEaseForAnnotation, path),
            RestEaseMethod = new RestEaseInterfaceMethod
            {
                ReturnType = MapReturnType(returnType),
                Name = methodRestEaseMethodName,
                Parameters = methodParameterList
            }
        };

        if (requestDetails?.IsExtension == true)
        {
            var combinedMethodParameterList = new List<RestEaseParameter>
            {
                new ()
                {
                    ValidIdentifier = "api",
                    IdentifierWithType = new PropertyDto($"this {@interface.Name}", "api"),
                    IdentifierRestEasePrefix = "this",
                    Summary = "The Api"
                }
            };
            combinedMethodParameterList.AddRange(methodParameterList.Where(p => !p.IsSpecial));
            combinedMethodParameterList.AddRange(extensionMethodParameterList);

            method.ExtensionMethodDetails = new RestEaseInterfaceMethodDetails
            {
                Summary = operation.Summary ?? $"{methodRestEaseMethodName} ({path})",
                SummaryParameters = combinedMethodParameterList.Select(mp => new RestEaseSummaryParameter
                {
                    ValidIdentifier = mp.ValidIdentifier,
                    IdentifierWithRestEase = mp.IdentifierWithRestEase,
                    Summary = mp.Summary
                }).ToList(),
                RestEaseMethod = new RestEaseInterfaceMethod
                {
                    ReturnType = method.RestEaseMethod.ReturnType,
                    Name = method.RestEaseMethod.Name,
                    Parameters = combinedMethodParameterList
                }
            };
            method.ExtensionMethodParameters = extensionMethodParameterList;
            method.ExtensionMethodContentType = requestDetails.DetectedContentType;
        }

        return method;
    }

    private string MapResponse(RestEaseInterface @interface, OpenApiResponses responses, string methodRestEaseMethodName, string? directory)
    {
        var returnTypes = new List<string>();

        foreach (var response in responses.Where(r => r.Value != null))
        {
            if (TryGetOpenApiMediaType(
                    response.Value.Content,
                    SupportedContentType.ApplicationJson,
                    out OpenApiMediaType? responseJson, out _))
            {
                var returnType = GetReturnType(@interface, responseJson.Schema, methodRestEaseMethodName, directory);
                if (returnType is not null)
                {
                    returnTypes.Add(FixReservedType(returnType));
                }
            }
            else if (Settings.ReturnResponseObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified)
            {
                // It's not JSON, just use object
                returnTypes.Add("object");
            }
        }

        if (returnTypes.Count == 1)
        {
            return returnTypes.First();
        }

        switch (Settings.PreferredMultipleResponsesType)
        {
            case MultipleResponsesType.First:
                return returnTypes.First();

            case MultipleResponsesType.AnyOf when returnTypes.Count > 0:
                var distinct = returnTypes.Distinct().ToArray();
                return distinct.Length > 1 ? $"Response<AnyOf<{string.Join(", ", distinct)}>>" : distinct.First();

            default:
                return "Response<object>";
        }
    }

    private string? GetReturnType(RestEaseInterface @interface, OpenApiSchema? schema, string methodRestEaseMethodName, string? directory)
    {
        string nullable = schema?.Nullable == true ? "?" : string.Empty;

        switch (schema?.GetSchemaType())
        {
            case SchemaType.String:
                return "string";

            case SchemaType.Integer:
                return schema.GetSchemaFormat() switch
                {
                    SchemaFormat.Int64 => $"long{nullable}",
                    _ => $"int{nullable}"
                };

            case SchemaType.Boolean:
                return $"bool{nullable}";

            case SchemaType.Number:
                return schema.GetSchemaFormat() switch
                {
                    SchemaFormat.Float => $"float{nullable}",
                    _ => $"double{nullable}"
                };

            case SchemaType.Array:
                var arrayType = schema.Items.Reference != null
                    ? MakeValidReferenceId(schema.Items.Reference.Id)
                    : _schemaMapper.MapSchema(@interface, schema.Items, string.Empty, null, false, true, null, directory).First.Type;

                return MapArrayType(FixReservedType(arrayType));

            case SchemaType.Object:
            case SchemaType.Unknown:
                var propertyReference = _schemaMapper.TryMapPropertyReference(@interface, schema, string.Empty, directory);
                if (propertyReference != null)
                {
                    return propertyReference.Type;
                }
                else if (schema.AdditionalProperties != null)
                {
                    // Use AdditionalProperties
                    var additionalResult = _schemaMapper.MapSchema(@interface, schema.AdditionalProperties, string.Empty, null, schema.AdditionalProperties.Nullable, false, null, directory);
                    if (additionalResult.IsFirst)
                    {
                        return additionalResult.First.Type;
                    }

                    if (additionalResult.IsSecond && additionalResult.Second.Count == 0)
                    {
                        // "Microsoft.AspNetCore.Mvc.ProblemDetails" has "additionalProperties": { }
                        return null;
                    }

                    throw new InvalidOperationException($"AdditionalProperties should return a single {nameof(PropertyDto)} or an empty object.");
                }
                else
                {
                    // Object is defined `inline`, create a new Model and use that one.
                    var className = !string.IsNullOrEmpty(schema.Title)
                        ? MakeValidClassName(schema.Title)
                        : $"{methodRestEaseMethodName.ToPascalCase()}Result";

                    var existingModel = @interface.ExtraModels.FirstOrDefault(m => string.Equals(m.ClassName, className, StringComparison.InvariantCultureIgnoreCase));
                    if (existingModel == null)
                    {
                        var inlineModel = _schemaMapper.MapSchema(@interface, schema, string.Empty, null, false, true, null, directory);
                        if (inlineModel.IsSecond)
                        {
                            var newModel = new RestEaseModel
                            {
                                Description = schema.Description,
                                Namespace = Settings.Namespace,
                                ClassName = className,
                                Properties = inlineModel.Second,
                                Priority = 1002
                            };
                            @interface.ExtraModels.Add(newModel);
                        }
                    }

                    return className;
                }

            default:
                if (schema?.OneOf.Any() == true || schema?.AnyOf.Any() == true)
                {
                    if (Settings.GenerateAndUseModelForAnyOfOrOneOf)
                    {
                        var dummyOpenApiSchema = new OpenApiSchema
                        {
                            Type = "object",
                            Properties = new Dictionary<string, OpenApiSchema>()
                        };

                        foreach (var one in schema.OneOf)
                        {
                            var type = GetReturnType(@interface, one, string.Empty, directory) ?? "object";
                            dummyOpenApiSchema.Properties.Add(type, one);
                        }

                        foreach (var one in schema.AnyOf)
                        {
                            var type = GetReturnType(@interface, one, string.Empty, directory) ?? "object";
                            dummyOpenApiSchema.Properties.Add(type, one);
                        }

                        string methodPostFix = schema.OneOf.Any() ? "OneOf" : "AnyOf";
                        return GetReturnType(@interface, dummyOpenApiSchema, $"{methodRestEaseMethodName}{methodPostFix}", directory);
                    }

                    return "object";
                }
                else if (Settings.ReturnResponseObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified)
                {
                    return "object";
                }
                else
                {
                    return null;
                }
        }
    }

    private RequestDetails MapRequestDetails(
        RestEaseInterface @interface,
        MediaTypeInfo detected,
        ICollection<RestEaseParameter> bodyParameterList,
        List<RestEaseParameter> extensionMethodParameterList,
        string bodyParameterDescription,
        string? directory)
    {
        if (detected.Key == SupportedContentType.MultipartFormData)
        {
            var schema = detected.Value.Schema;

            string httpContentDescription;
            if (!Settings.GenerateMultipartFormDataExtensionMethods)
            {
                httpContentDescription = "Manually add an extension method to support the exact parameters. See https://github.com/canton7/RestEase#wrapping-other-methods for more info.";
            }
            else
            {
                httpContentDescription = "An extension method is generated to support the exact parameters.";

                if (schema.Properties.Any())
                {
                    extensionMethodParameterList.AddRange(schema.Properties.Select(p => BuildValidParameter(@interface, p.Key, p.Value, p.Value.Nullable, p.Value.Description, null, Array.Empty<string>(), directory)));
                }
                else if (schema.GetSchemaType() == SchemaType.Array)
                {
                    extensionMethodParameterList.Add(BuildValidParameter(@interface, "content", schema, schema.Nullable, schema.Description, null, Array.Empty<string>(), directory));
                }
            }

            bodyParameterList.Add(new RestEaseParameter
            {
                Required = true,
                ValidIdentifier = "content",
                IdentifierWithType = new PropertyDto("HttpContent", "content"),
                IdentifierRestEasePrefix = "[Body]",
                Summary = httpContentDescription,
                IsSpecial = true
            });

            return new RequestDetails
            {
                DetectedContentType = detected.Key,
                IsExtension = true
            };
        }

        if (detected.Key == SupportedContentType.ApplicationOctetStream)
        {
            string httpContentDescription;
            if (!Settings.GenerateApplicationOctetStreamExtensionMethods)
            {
                httpContentDescription = "Manually add an extension method to support the exact parameters. See https://github.com/canton7/RestEase#wrapping-other-methods for more info.";
            }
            else
            {
                httpContentDescription = "An extension method is generated to support the exact parameters.";
                var extensionParameter = BuildValidParameter(@interface, "file", detected.Value.Schema, true, "The content.", null, Array.Empty<string>(), directory);
                extensionMethodParameterList.Add(extensionParameter);
                extensionMethodParameterList.AddRange(detected.Value.Schema.Properties.Select(p => BuildValidParameter(@interface, p.Key, p.Value, p.Value.Nullable, p.Value.Description, null, Array.Empty<string>(), directory)));
            }

            bodyParameterList.Add(new RestEaseParameter
            {
                Required = true,
                ValidIdentifier = "content",
                IdentifierWithType = new PropertyDto("HttpContent", "content"),
                IdentifierRestEasePrefix = "[Body]",
                Summary = httpContentDescription,
                IsSpecial = true
            });

            return new RequestDetails
            {
                DetectedContentType = detected.Key,
                IsExtension = true
            };
        }

        if (detected.Key == SupportedContentType.ApplicationFormUrlEncoded)
        {
            string description;
            if (!Settings.GenerateFormUrlEncodedExtensionMethods)
            {
                description = "Manually add an extension method to support the exact parameters.";
            }
            else
            {
                description = "An extension method is generated to support the exact parameters.";
                extensionMethodParameterList.AddRange(detected.Value.Schema.Properties.Select(p => BuildValidParameter(@interface, p.Key, p.Value, p.Value.Nullable, p.Value.Description, null, Array.Empty<string>(), directory)));
            }

            bodyParameterList.Add(new RestEaseParameter
            {
                Required = true,
                ValidIdentifier = "form",
                IdentifierWithType = new PropertyDto("IDictionary<string, object>", "form"),
                IdentifierRestEasePrefix = "[Body(BodySerializationMethod.UrlEncoded)]",
                Summary = description,
                IsSpecial = true
            });

            return new RequestDetails
            {
                DetectedContentType = detected.Key,
                IsExtension = true
            };
        }

        if (detected.Key is SupportedContentType.ApplicationJson or SupportedContentType.ApplicationXml)
        {
            string? bodyParameter = null;
            switch (detected.Value.Schema?.GetSchemaType())
            {
                case SchemaType.Array:
                    string arrayType = detected.Value.Schema.Items.Reference != null
                        ? MakeValidReferenceId(detected.Value.Schema.Items.Reference.Id)
                        : _schemaMapper.MapSchema(@interface, detected.Value.Schema.Items, string.Empty, null, false, true, null, directory).ToString();
                    bodyParameter = MapArrayType(arrayType);
                    break;

                case SchemaType.Object:
                case SchemaType.Unknown:
                    bodyParameter = detected.Value.Schema.Reference != null ? MakeValidReferenceId(detected.Value.Schema.Reference.Id) : null;
                    break;
            }

            if (!string.IsNullOrEmpty(bodyParameter))
            {
                bodyParameterList.Add(new RestEaseParameter
                {
                    Required = true,
                    ValidIdentifier = "content",
                    IdentifierWithType = new PropertyDto(FixReservedType(bodyParameter!), "content"),
                    IdentifierRestEasePrefix = "[Body]",
                    Summary = detected.Value.Schema?.Description ?? bodyParameterDescription
                });
            }

            return new RequestDetails
            {
                DetectedContentType = detected.Key
            };
        }

        return new RequestDetails();
    }

    private RequestDetails? MapRequest(
        RestEaseInterface @interface,
        OpenApiOperation operation,
        ICollection<RestEaseParameter> bodyParameterList,
        List<RestEaseParameter> extensionMethodParameterList,
        string? directory)
    {
        var supportedMediaTypeInfoList = new List<MediaTypeInfo>();
        foreach (SupportedContentType key in Enum.GetValues(typeof(SupportedContentType)))
        {
            if (TryGetOpenApiMediaType(operation.RequestBody.Content, key, out var mediaType, out var detectedContentType))
            {
                supportedMediaTypeInfoList.Add(new MediaTypeInfo(key, mediaType, detectedContentType));
            }
        }

        if (supportedMediaTypeInfoList.Count == 0)
        {
            return null;
        }

        MediaTypeInfo? detected = null;
        if (operation.RequestBody.Content.Count == 1 && supportedMediaTypeInfoList.Count == 1)
        {
            detected = supportedMediaTypeInfoList.First();
        }
        else if (operation.RequestBody.Content.Count == supportedMediaTypeInfoList.Count)
        {
            if (Settings.PreferredContentType == ContentType.ApplicationXml && supportedMediaTypeInfoList.Any(sc => sc.Key == SupportedContentType.ApplicationXml))
            {
                detected = supportedMediaTypeInfoList.First(sc => sc.Key == SupportedContentType.ApplicationXml);
            }
            else
            {
                detected = supportedMediaTypeInfoList.First(sc => sc.Key == SupportedContentType.ApplicationJson);
            }
        }

        if (detected == null)
        {
            if (Settings.ForceContentTypeToApplicationJson)
            {
                detected =
                    supportedMediaTypeInfoList.FirstOrDefault(m => m.Key == SupportedContentType.ApplicationJson) ??
                    supportedMediaTypeInfoList.First();

                var requestDetails = MapRequestDetails(@interface, detected, bodyParameterList, extensionMethodParameterList, operation.RequestBody.Description, directory);
                requestDetails.ContentTypes = new List<string>();
                requestDetails.DetectedContentType = SupportedContentType.ApplicationJson;

                return requestDetails;
            }
            else
            {
                detected = supportedMediaTypeInfoList.First();

                var requestDetails = MapRequestDetails(@interface, detected, bodyParameterList, extensionMethodParameterList, operation.RequestBody.Description, directory);
                requestDetails.ContentTypes = operation.RequestBody.Content.Keys;
                requestDetails.DetectedContentType = null;

                return requestDetails;
            }
        }

        return MapRequestDetails(@interface, detected, bodyParameterList, extensionMethodParameterList, operation.RequestBody.Description, directory);
    }

    private string GeneratedRestEaseMethodName(string path, OpenApiOperation operation, string httpMethodPascalCased)
    {
        string methodRestEaseMethod;
        if (Settings.UseOperationIdAsMethodName && !string.IsNullOrEmpty(operation.OperationId) && char.IsLetter(operation.OperationId[0]))
        {
            methodRestEaseMethod = operation.OperationId.ToValidIdentifier(CasingType.Pascal);
        }
        else
        {
            var list = new List<string> { httpMethodPascalCased };

            bool isFirst = true;
            foreach (string part in path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (part.StartsWith("{"))
                {
                    var text = part.Split(new[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries)[0].ToPascalCase();

                    list.Add(isFirst ? $"By{text}" : $"And{text}");

                    isFirst = false;
                }
                else
                {
                    list.Add(part.ToPascalCase());
                }
            }

            methodRestEaseMethod = string.Join("", list);
        }

        return Regex.Replace(methodRestEaseMethod, @"Async$", string.Empty);
    }

    private string MapReturnType(object returnType)
    {
        if (returnType is not string returnTypeAsString)
        {
            return "Task";
        }

        if (returnTypeAsString == Settings.ModelsNamespace)
        {
            returnTypeAsString = $"{Settings.ModelsNamespace}.{returnTypeAsString}";
        }

        switch (Settings.MethodReturnType)
        {
            case MethodReturnType.String:
                return "Task<string>";

            case MethodReturnType.HttpResponseMessage:
                return "Task<HttpResponseMessage>";

            case MethodReturnType.Response:
                return $"Task<Response<{returnTypeAsString}>>";

            case MethodReturnType.Stream:
                return "Task<Stream>";

            default:
                return $"Task<{returnTypeAsString}>";
        }
    }

    private RestEaseParameter BuildValidParameter(
        RestEaseInterface @interface,
        string identifier,
        OpenApiSchema schema,
        bool required,
        string description,
        ParameterLocation? parameterLocation,
        string[] extraAttributes,
        string? directory)
    {
        var attributes = new List<string>();
        string validIdentifier = identifier.ToValidIdentifier(CasingType.Camel);
        bool parameterIsRenamed = identifier != validIdentifier;

        string restEaseParameterAnnotation = parameterLocation != null ? parameterLocation.ToString() : string.Empty;

        bool canBeNull = schema.Enum == null;
        bool isNullPostfix = !required && canBeNull && Settings.MakeNonRequiredParametersOptional;

        if (parameterLocation == ParameterLocation.Header)
        {
            attributes.Add($"\"{identifier}\"");
        }

        PropertyDto identifierWithType;
        if (parameterIsRenamed)
        {
            switch (parameterLocation)
            {
                case ParameterLocation.Path:
                case ParameterLocation.Query:
                    attributes.Add($"Name = \"{identifier}\"");
                    break;
            }

            attributes.AddRange(extraAttributes);

            identifierWithType = _schemaMapper.MapSchema(@interface, schema, string.Empty, validIdentifier, !required, false, null, directory).First;

            identifierWithType = FixReservedType(identifierWithType);

            return new RestEaseParameter
            {
                ParameterLocation = parameterLocation,
                Required = required,
                Identifier = identifier,
                ValidIdentifier = validIdentifier,
                SchemaType = schema.GetSchemaType(),
                SchemaFormat = schema.GetSchemaFormat(),
                IdentifierWithType = identifierWithType,
                IdentifierRestEasePrefix = $"[{restEaseParameterAnnotation}({string.Join(", ", attributes)})]",
                IsNullPostfix = isNullPostfix,
                Summary = description
            };
        }

        string extraAttributesBetweenParentheses = extraAttributes.Length == 0 ? string.Empty : $"({string.Join(", ", extraAttributes)})";
        identifierWithType = _schemaMapper.MapSchema(@interface, schema, string.Empty, identifier, !required, false, null, directory);

        identifierWithType = FixReservedType(identifierWithType);

        return new RestEaseParameter
        {
            ParameterLocation = parameterLocation,
            Required = required,
            Identifier = identifier,
            ValidIdentifier = identifier,
            SchemaType = schema.GetSchemaType(),
            SchemaFormat = schema.GetSchemaFormat(),
            IdentifierWithType = identifierWithType, // 
            IdentifierRestEasePrefix = $"[{restEaseParameterAnnotation}{extraAttributesBetweenParentheses}]",
            IsNullPostfix = isNullPostfix,
            Summary = description
        };
    }

    private PropertyDto FixReservedType(PropertyDto identifierWithType)
    {
        return !IdentifierUtils.IsReserved(identifierWithType.Type)
            ? identifierWithType
            : identifierWithType with { Type = $"{Settings.ModelsNamespace}.{identifierWithType.Type}" };
    }

    private string FixReservedType(string type)
    {
        return IdentifierUtils.IsReserved(type) ? $"{Settings.ModelsNamespace}.{type}" : type;
    }

    private static bool TryGetOpenApiMediaType(
        IDictionary<string, OpenApiMediaType> contentTypes,
        SupportedContentType contentType,
        [NotNullWhen(true)] out OpenApiMediaType? mediaType,
        [NotNullWhen(true)] out string? detectedContentType)
    {
        var contentTypesIgnoreCase = new Dictionary<string, OpenApiMediaType>(contentTypes, StringComparer.InvariantCultureIgnoreCase);

        string contentDescription = contentType.GetDescription();
        if (contentTypesIgnoreCase.TryGetValue(contentDescription, out mediaType))
        {
            detectedContentType = contentDescription;
            return true;
        }

        var key = contentTypesIgnoreCase.Keys.FirstOrDefault(ct => ct.Contains(contentDescription));
        if (key != null)
        {
            mediaType = contentTypesIgnoreCase[key];
            detectedContentType = key;
            return true;
        }

        //if (contentTypesIgnoreCase.Count > 0)
        //{
        //    mediaType = contentTypesIgnoreCase.First().Value;
        //    return true;
        //}

        detectedContentType = default;
        return false;
    }
}