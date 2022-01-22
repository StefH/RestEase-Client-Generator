using System.Text.RegularExpressions;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Constants;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
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
        string name = CSharpUtils.CreateValidIdentifier(Settings.ApiName, CasingType.Pascal);
        string interfaceName = $"I{name}Api";

        var @interface = new RestEaseInterface
        {
            Name = interfaceName,
            Namespace = Settings.Namespace,
            Summary = openApiDocument.Info?.Description ?? name
        };

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
                (Settings.PreferredSecurityDefinitionType == SecurityDefinitionType.Automatic || Settings.PreferredSecurityDefinitionType == SecurityDefinitionType.Header))
            {
                @interface.VariableHeaders.Add(new RestEaseInterfaceHeader { ValidIdentifier = header.IdentifierName, Name = header.Name });
            }
            else if (query != null &&
                     (Settings.PreferredSecurityDefinitionType == SecurityDefinitionType.Automatic || Settings.PreferredSecurityDefinitionType == SecurityDefinitionType.Query))
            {
                @interface.ConstantQueryParameters.Add(new RestEaseInterfaceQueryParameter
                {
                    Name = query.Name,
                    IdentifierWithType = $"string {query.IdentifierName}"
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
                    @interface.VariableHeaders.Add(new RestEaseInterfaceHeader { Name = parameter.Identifier, ValidIdentifier = parameter.ValidIdentifier });
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
        if (path == "/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/containerGroups")
        {
            int x = 0;
        }

        if (path == "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/restart")
        {
            int yy = 0;
        }

        if (path.Contains("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}"))
        {
            var StorageAccount = 9998;
        }

        string methodRestEaseForAnnotation = httpMethod.ToPascalCase();

        string methodRestEaseMethodName = GeneratedRestEaseMethodName(path, operation, methodRestEaseForAnnotation);

        var headerParameterList = operation.Parameters
            .Where(p => p.In == ParameterLocation.Header && p.Schema.GetSchemaType() != SchemaType.Object)
            .Select(p => BuildValidParameter(@interface, p.Name, p.Schema, p.Required, p.Description, p.In, Array.Empty<string>(), directory))
            .ToList();

        var pathParameterList = operation.Parameters
            .Where(p => p.In == ParameterLocation.Path && p.Schema.GetSchemaType() != SchemaType.Object)
            .Select(p => BuildValidParameter(@interface, p.Name, p.Schema, p.Required, p.Description, p.In, Array.Empty<string>(), directory))
            .ToList();

        var queryParameterList = operation.Parameters
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
            else if (requestDetails.ContentTypes.Count > 1)
            {
                headerParameterList.Add(new RestEaseParameter
                {
                    Required = true,
                    Summary = "The Content-Type",
                    ValidIdentifier = "contentType",
                    IdentifierWithRestEase = $"[Header(\"{HttpKnownHeaderNames.ContentType}\")] string contentType",
                    IdentifierWithType = "string contentType",
                    IdentifierWithTypePascalCase = "string ContentType",
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

        if (path == "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}")
        {
            int a1 = 0;
        }
        if (path == "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}")
        {
            int x = 0;
        }
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
            RestEaseAttribute = $"[{methodRestEaseForAnnotation}(\"{path}\")]",
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
                new RestEaseParameter
                {
                    ValidIdentifier = "api",
                    IdentifierWithTypePascalCase = null,
                    IdentifierWithType = $"this {@interface.Name} api",
                    IdentifierWithRestEase = $"this {@interface.Name} api",
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
                    out OpenApiMediaType responseJson, out var _))
            {
                returnTypes.Add(GetReturnType(@interface, responseJson.Schema, methodRestEaseMethodName, directory));
            }
            else
            {
                // It's not JSON, just use object
                returnTypes.Add("Response<object>");
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

            case MultipleResponsesType.AnyOf:
                var distinct = returnTypes.Distinct().ToArray();
                return distinct.Length > 1 ? $"AnyOf<{string.Join(", ", distinct)}>" : distinct.First();

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
                switch (schema.GetSchemaFormat())
                {
                    case SchemaFormat.Int64:
                        return $"long{nullable}";

                    default:
                        return $"int{nullable}";
                }

            case SchemaType.Boolean:
                return $"bool{nullable}";

            case SchemaType.Number:
                switch (schema.GetSchemaFormat())
                {
                    case SchemaFormat.Float:
                        return $"float{nullable}";

                    default:
                        return $"double{nullable}";
                }

            case SchemaType.Array:
                string arrayType = schema.Items.Reference != null
                    ? MakeValidModelName(schema.Items.Reference.Id)
                    : _schemaMapper.MapSchema(@interface, schema.Items, null, false, true, null, directory).First.Type;

                return MapArrayType(arrayType);

            case SchemaType.Object:
            case SchemaType.Unknown:
                if (schema.Reference != null)
                {
                    if (schema.Reference.IsLocal)
                    {
                        var className = MakeValidModelName(schema.Reference.Id);
                        if (@interface.ExtraModels.All(m => m.ClassName != className) || @interface.ExtraEnums.All(m => m.EnumName != className))
                        {
                            var extraModel = _schemaMapper.MapSchema(@interface, schema, className, false, true, null, directory);

                            if (extraModel.IsFirst && Settings.PreferredEnumType == EnumType.Enum)
                            {
                                // It's a single value, so probably -enum
                                var newEnum = new RestEaseEnum
                                {
                                    Namespace = Settings.Namespace,
                                    EnumName = className,
                                    Values = null,
                                    EnumType = Settings.PreferredEnumType
                                };
                                @interface.ExtraEnums.Add(newEnum);
                            }
                            else
                            {
                                var newModel = new RestEaseModel
                                {
                                    Namespace = Settings.Namespace,
                                    ClassName = className,
                                    Properties = extraModel.Second
                                };
                                @interface.ExtraModels.Add(newModel);
                            }
                        }

                        // Internal Local defined object
                        return className;
                    }

                    if (schema.Reference.IsExternal)
                    {
                        return new ExternalModelMapper(Settings, @interface).Map(schema, directory);
                    }

                    throw new InvalidOperationException();
                }
                else if (schema.AdditionalProperties != null)
                {
                    // Use AdditionalProperties
                    var additionalResult = _schemaMapper.MapSchema(@interface, schema.AdditionalProperties, null, schema.AdditionalProperties.Nullable, false, null, directory);
                    if (additionalResult.IsFirst)
                    {
                        return additionalResult.First.Type;
                    }

                    throw new InvalidOperationException($"AdditionalProperties should return a single {nameof(PropertyDto)}");
                }
                else
                {
                    // Object is defined `inline`, create a new Model and use that one.
                    var className = !string.IsNullOrEmpty(schema.Title)
                        ? CSharpUtils.CreateValidIdentifier(schema.Title, CasingType.Pascal)
                        : $"{methodRestEaseMethodName.ToPascalCase()}Result";

                    var existingModel = @interface.ExtraModels.FirstOrDefault(m => m.ClassName == className);
                    if (existingModel == null)
                    {
                        var inlineModel = _schemaMapper.MapSchema(@interface, schema, null, false, true, null, directory);
                        if (inlineModel.IsSecond)
                        {
                            var newModel = new RestEaseModel
                            {
                                Namespace = Settings.Namespace,
                                ClassName = className,
                                Properties = inlineModel.Second
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
                            var type = GetReturnType(@interface, one, null, directory);
                            dummyOpenApiSchema.Properties.Add(type, one);
                        }

                        foreach (var one in schema.AnyOf)
                        {
                            var type = GetReturnType(@interface, one, null, directory);
                            dummyOpenApiSchema.Properties.Add(type, one);
                        }

                        string methodPostFix = schema.OneOf.Any() ? "OneOf" : "AnyOf";
                        return GetReturnType(@interface, dummyOpenApiSchema, $"{methodRestEaseMethodName}{methodPostFix}", directory);
                    }

                    return "object";
                }
                else if (Settings.ReturnResponseObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified)
                {
                    return "Response<object>";
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
            string httpContentDescription;
            if (!Settings.GenerateMultipartFormDataExtensionMethods)
            {
                httpContentDescription = "Manually add an extension method to support the exact parameters. See https://github.com/canton7/RestEase#wrapping-other-methods for more info.";
            }
            else
            {
                httpContentDescription = "An extension method is generated to support the exact parameters.";
                extensionMethodParameterList.AddRange(detected.Value.Schema.Properties.Select(p => BuildValidParameter(@interface, p.Key, p.Value, p.Value.Nullable, p.Value.Description, null, Array.Empty<string>(), directory)));
            }

            bodyParameterList.Add(new RestEaseParameter
            {
                Required = true,
                ValidIdentifier = "content",
                IdentifierWithType = "HttpContent content",
                IdentifierWithTypePascalCase = "HttpContent Content",
                IdentifierWithRestEase = "[Body] HttpContent content",
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
                IdentifierWithType = "HttpContent content",
                IdentifierWithTypePascalCase = "HttpContent Content",
                IdentifierWithRestEase = "[Body] HttpContent content",
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
                IdentifierWithType = "IDictionary<string, object> form",
                IdentifierWithTypePascalCase = "IDictionary<string, object> Form",
                IdentifierWithRestEase = "[Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> form",
                Summary = description,
                IsSpecial = true
            });

            return new RequestDetails
            {
                DetectedContentType = detected.Key,
                IsExtension = true
            };
        }

        if (detected.Key == SupportedContentType.ApplicationJson || detected.Key == SupportedContentType.ApplicationXml)
        {
            string? bodyParameter = null;
            switch (detected.Value.Schema?.GetSchemaType())
            {
                case SchemaType.Array:
                    string arrayType = detected.Value.Schema.Items.Reference != null
                        ? MakeValidModelName(detected.Value.Schema.Items.Reference.Id)
                        : _schemaMapper.MapSchema(@interface, detected.Value.Schema.Items, null, false, true, null, directory).ToString();
                    bodyParameter = MapArrayType(arrayType);
                    break;

                case SchemaType.Object:
                    bodyParameter = detected.Value.Schema.Reference != null ? MakeValidModelName(detected.Value.Schema.Reference.Id) : null;
                    break;
            }

            if (!string.IsNullOrEmpty(bodyParameter))
            {
                string bodyParameterIdentifierName = "content";
                bodyParameterList.Add(new RestEaseParameter
                {
                    Required = true,
                    ValidIdentifier = bodyParameterIdentifierName,
                    IdentifierWithType = $"{bodyParameter} {bodyParameterIdentifierName}",
                    IdentifierWithTypePascalCase = $"{bodyParameter} {bodyParameterIdentifierName.ToPascalCase()}",
                    IdentifierWithRestEase = $"[Body] {bodyParameter} {bodyParameterIdentifierName}",
                    Summary = detected.Value.Schema?.Description ?? bodyParameterDescription
                });
            }

            return new RequestDetails
            {
                DetectedContentType = detected.Key
            };
        }

        return null;
    }

    private RequestDetails? MapRequest(
        RestEaseInterface @interface,
        OpenApiOperation operation,
        ICollection<RestEaseParameter> bodyParameterList,
        List<RestEaseParameter> extensionMethodParameterList,
        string? directory)
    {
        MediaTypeInfo? detected = null;

        var supportedMediaTypeInfoList = new List<MediaTypeInfo>();
        foreach (SupportedContentType key in Enum.GetValues(typeof(SupportedContentType)))
        {
            if (TryGetOpenApiMediaType(operation.RequestBody.Content, key, out var mediaType, out var detectedContentType))
            {
                supportedMediaTypeInfoList.Add(new MediaTypeInfo { Key = key, Value = mediaType, ContentType = detectedContentType });
            }
        }

        if (supportedMediaTypeInfoList.Count == 0)
        {
            return null;
        }

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
            returnTypeAsString = $"{Settings.ModelsNamespace}.{Settings.ModelsNamespace}";
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
        string validIdentifier = CSharpUtils.CreateValidIdentifier(identifier, CasingType.Camel);

        string restEaseParameterAnnotation = parameterLocation != null ? parameterLocation.ToString() : string.Empty;

        bool canBeNull = schema.Enum == null;
        string isNullPostfix = !required && canBeNull && Settings.MakeNonRequiredParametersOptional ? " = null" : string.Empty;

        if (parameterLocation == ParameterLocation.Header)
        {
            attributes.Add($"\"{identifier}\"");
        }

        string identifierWithType;
        if (identifier != validIdentifier)
        {
            switch (parameterLocation)
            {
                case ParameterLocation.Path:
                case ParameterLocation.Query:
                    attributes.Add($"Name = \"{identifier}\"");
                    break;
            }

            attributes.AddRange(extraAttributes);

            identifierWithType = $"{_schemaMapper.MapSchema(@interface, schema, validIdentifier, !required, false, null, directory)}";

            return new RestEaseParameter
            {
                ParameterLocation = parameterLocation,
                Required = required,
                Identifier = identifier,
                ValidIdentifier = validIdentifier,
                SchemaType = schema.GetSchemaType(),
                SchemaFormat = schema.GetSchemaFormat(),
                IdentifierWithType = $"{identifierWithType}",
                IdentifierWithTypePascalCase = $"{_schemaMapper.MapSchema(@interface, schema, validIdentifier, !required, true, null, directory)}",
                IdentifierWithRestEase = $"[{restEaseParameterAnnotation}({string.Join(", ", attributes)})] {identifierWithType}{isNullPostfix}",
                Summary = description
            };
        }

        string extraAttributesBetweenParentheses = extraAttributes.Length == 0 ? string.Empty : $"({string.Join(", ", extraAttributes)})";
        identifierWithType = $"{_schemaMapper.MapSchema(@interface, schema, identifier, !required, false, null, directory)}";

        return new RestEaseParameter
        {
            ParameterLocation = parameterLocation,
            Required = required,
            Identifier = identifier,
            ValidIdentifier = identifier,
            SchemaType = schema.GetSchemaType(),
            SchemaFormat = schema.GetSchemaFormat(),
            IdentifierWithType = $"{identifierWithType}",
            IdentifierWithTypePascalCase = $"{_schemaMapper.MapSchema(@interface, schema, identifier, !required, true, null, directory)}",
            IdentifierWithRestEase = $"[{restEaseParameterAnnotation}{extraAttributesBetweenParentheses}] {identifierWithType}{isNullPostfix}",
            Summary = description
        };
    }

    private bool TryGetOpenApiMediaType(IDictionary<string, OpenApiMediaType> contentTypes, SupportedContentType contentType, out OpenApiMediaType mediaType, out string detectedContentType)
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

        detectedContentType = string.Empty;
        return false;
    }
}