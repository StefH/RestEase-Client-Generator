using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Constants;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using RestEaseClientGenerator.Models.Internal;

namespace RestEaseClientGenerator.Mappers
{
    internal class InterfaceMapper : BaseMapper
    {
        public InterfaceMapper(GeneratorSettings settings) : base(settings)
        {
        }

        public RestEaseInterface Map(OpenApiDocument openApiDocument)
        {
            string name = CSharpUtils.CreateValidIdentifier(Settings.ApiName, CasingType.Pascal);
            string interfaceName = $"I{name}Api";

            var @interface = new RestEaseInterface
            {
                Name = interfaceName,
                Namespace = Settings.Namespace,
            };

            foreach (var path in openApiDocument.Paths)
            {
                MapPath(@interface, path.Key, path.Value);
            }
            //var methods = paths.Select(p => MapPath(interfaceName, p.Key, p.Value)).SelectMany(x => x).ToList();

            //var counts = methods
            //    .GroupBy(method => method.RestEaseMethod.Name + method.RestEaseMethod.Parameters)
            //    .Where(grouping => grouping.Count() > 1)
            //    .ToDictionary(grouping => grouping.Key, p => p.Count());

            //// modify the list, going backwards so we can take advantage of our counts.
            //for (int i = methods.Count - 1; i >= 0; i--)
            //{
            //    string key = methods[i].RestEaseMethod.Name + methods[i].RestEaseMethod.Parameters;
            //    if (counts.ContainsKey(key))
            //    {
            //        // add the suffix and decrement the number of duplicates left to tag.
            //        methods[i].RestEaseMethod.Name += $"{counts[key]--}";
            //    }
            //}

            return @interface;
        }

        private void MapPath(RestEaseInterface @interface, string path, OpenApiPathItem pathItem)
        {
            foreach (var restEaseInterfaceMethodDetails in pathItem.Operations.Select(o => MapOperationToMappingModel(@interface, path, o.Key.ToString(), o.Value)))
            {
                @interface.Methods.Add(restEaseInterfaceMethodDetails);
            }
        }

        private RestEaseInterfaceMethodDetails MapOperationToMappingModel(RestEaseInterface @interface, string path, string httpMethod, OpenApiOperation operation)
        {
            string methodRestEaseForAnnotation = httpMethod.ToPascalCase();

            string methodRestEaseMethodName = GeneratedRestEaseMethodName(path, operation, methodRestEaseForAnnotation);

            var pathParameterList = operation.Parameters
                .Where(p => p.In == ParameterLocation.Path && p.Schema.GetSchemaType() != SchemaType.Object)
                .Select(p => BuildValidParameter(p.Name, p.Schema, p.Required, p.Description, "Path"))
                .ToList();

            var queryParameterList = operation.Parameters
                .Where(p => p.In == ParameterLocation.Query && p.Schema.GetSchemaType() != SchemaType.Object)
                .Select(p => BuildValidParameter(p.Name, p.Schema, p.Required, p.Description, "Query"))
                .ToList();

            var extensionMethodParameterList = new List<RestEaseParameter>();
            var bodyParameterList = new List<RestEaseParameter>();
            var headerParameterList = new List<RestEaseParameter>();

            var requestDetails = operation.RequestBody != null
                ? MapRequest(operation, bodyParameterList, extensionMethodParameterList)
                : null;

            var headers = new List<string>();
            if (requestDetails != null)
            {
                if (!string.IsNullOrEmpty(requestDetails.DetectedContentType))
                {
                    headers.Add($"[Header(\"{HttpKnownHeaderNames.ContentType}\", \"{requestDetails.DetectedContentType}\")]");
                }
                //else if (requestDetails.ContentTypes.Count == 1)
                //{
                //    headers.Add($"[Header(\"{HttpKnownHeaderNames.ContentType}\", \"{requestDetails.ContentTypes.First()}\")]");
                //}
                else if (requestDetails.ContentTypes.Count > 1)
                {
                    headerParameterList.Add(new RestEaseParameter
                    {
                        Required = true,
                        Summary = "The Content-Type",
                        Identifier = "contentType",
                        IdentifierWithRestEase = $"[Header(\"{HttpKnownHeaderNames.ContentType}\")] string contentType",
                        IdentifierWithType = "string contentType",
                        IsSpecial = false,
                        SchemaFormat = SchemaFormat.Undefined,
                        SchemaType = SchemaType.String
                    });
                }
            }

            var methodParameterList = pathParameterList
                .Union(headerParameterList)
                .Union(bodyParameterList)
                .Union(queryParameterList)
                .OrderByDescending(p => p.Required)
                .ToList();

            var response = operation.Responses.First();

            object returnType = null;
            if (response.Value != null && TryGetOpenApiMediaType(response.Value.Content, SupportedContentTypes.ApplicationJson, out OpenApiMediaType responseJson, out var _))
            {
                switch (responseJson.Schema?.GetSchemaType())
                {
                    case SchemaType.Array:
                        string arrayType = responseJson.Schema.Items.Reference != null ?
                            responseJson.Schema.Items.Reference.Id :
                            MapSchema(responseJson.Schema.Items, null, responseJson.Schema.Nullable).ToString();

                        returnType = MapArrayType(arrayType);
                        break;

                    case SchemaType.Object:
                        if (responseJson.Schema.Reference != null)
                        {
                            // Existing defined object
                            returnType = responseJson.Schema.Reference.Id;
                        }
                        else if (responseJson.Schema.AdditionalProperties != null)
                        {
                            // Use AdditionalProperties
                            returnType = MapSchema(responseJson.Schema.AdditionalProperties, null, responseJson.Schema.AdditionalProperties.Nullable, false);
                        }
                        else
                        {
                            // Object is defined `inline`, create a new Model and use that one.
                            string className = !string.IsNullOrEmpty(responseJson.Schema.Title)
                                ? CSharpUtils.CreateValidIdentifier(responseJson.Schema.Title, CasingType.Pascal)
                                : $"{methodRestEaseMethodName.ToPascalCase()}Result";

                            var existingModel = @interface.InlineModels.FirstOrDefault(m => m.ClassName == className);
                            if (existingModel == null)
                            {
                                var newModel = new RestEaseModel
                                {
                                    Namespace = Settings.Namespace,
                                    ClassName = className,
                                    Properties = MapSchema(responseJson.Schema, null, false) as ICollection<string>
                                };
                                @interface.InlineModels.Add(newModel);
                            }

                            returnType = className;
                        }
                        break;

                    default:
                        if (Settings.ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified)
                        {
                            returnType = "object";
                        }
                        break;
                }
            }

            var method = new RestEaseInterfaceMethodDetails
            {
                Headers = headers,
                Summary = operation.Summary ?? $"{methodRestEaseMethodName} ({path})",
                SummaryParameters = methodParameterList.Select(mp => $"<param name=\"{mp.Identifier}\">{mp.Summary.StripHtml()}</param>").ToList(),
                RestEaseAttribute = $"[{methodRestEaseForAnnotation}(\"{path}\")]",
                RestEaseMethod = new RestEaseInterfaceMethod
                {
                    ReturnType = MapReturnType(returnType),
                    Name = methodRestEaseMethodName,
                    ParametersAsString = string.Join(", ", methodParameterList.Select(mp => mp.IdentifierWithRestEase)),
                    Parameters = methodParameterList
                }
            };

            if (requestDetails?.IsExtension == true)
            {
                var combinedMethodParameterList = new List<RestEaseParameter>
                {
                    new RestEaseParameter
                    {
                        Identifier = "api",
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
                    SummaryParameters = combinedMethodParameterList.Select(mp => $"<param name=\"{mp.Identifier}\">{mp.Summary.StripHtml()}</param>").ToList(),
                    RestEaseMethod = new RestEaseInterfaceMethod
                    {
                        ReturnType = method.RestEaseMethod.ReturnType,
                        Name = method.RestEaseMethod.Name,
                        ParametersAsString = string.Join(", ", combinedMethodParameterList.Select(mp => mp.IdentifierWithType)),
                        Parameters = combinedMethodParameterList
                    }
                };
                method.ExtensionMethodParameters = extensionMethodParameterList;
                method.ExtensionMethodContentType = requestDetails.DetectedContentType;
            }

            return method;
        }

        private RequestDetails MapRequest(OpenApiOperation operation, ICollection<RestEaseParameter> bodyParameterList, List<RestEaseParameter> extensionMethodParameterList)
        {
            var supportedOpenApiMediaTypes = new Dictionary<string, OpenApiMediaType>();
            OpenApiMediaType detected = null;

            if (TryGetOpenApiMediaType(operation.RequestBody.Content, SupportedContentTypes.ApplicationJson, out var json, out var detectedJson))
            {
                supportedOpenApiMediaTypes.Add(detectedJson, json);
            }

            if (TryGetOpenApiMediaType(operation.RequestBody.Content, SupportedContentTypes.ApplicationXml, out var xml, out var detectedXml))
            {
                supportedOpenApiMediaTypes.Add(detectedXml, xml);
            }

            if (TryGetOpenApiMediaType(operation.RequestBody.Content, SupportedContentTypes.MultipartFormData, out var multipartFormData, out var detectedMultipartForm))
            {
                supportedOpenApiMediaTypes.Add(detectedMultipartForm, multipartFormData);
            }

            if (TryGetOpenApiMediaType(operation.RequestBody.Content, SupportedContentTypes.ApplicationOctetStream, out var octetStream, out var detectedOctetStream))
            {
                supportedOpenApiMediaTypes.Add(detectedOctetStream, octetStream);
            }

            if (TryGetOpenApiMediaType(operation.RequestBody.Content, SupportedContentTypes.ApplicationFormUrlEncoded, out var formUrlencoded, out var detectedFormUrl))
            {
                supportedOpenApiMediaTypes.Add(detectedFormUrl, formUrlencoded);
            }

            if (supportedOpenApiMediaTypes.Count == 0)
            {
                return null;
            }

            if (operation.RequestBody.Content.Count == 1 && supportedOpenApiMediaTypes.Count == 1)
            {
                detected = supportedOpenApiMediaTypes.First().Value;
            }
            else if (operation.RequestBody.Content.Count == supportedOpenApiMediaTypes.Count)
            {
                if (Settings.PreferredContentType == PreferredContentType.ApplicationXml && xml != null)
                {
                    detected = xml;
                }
                //else if (Settings.PreferredContentType == PreferredContentType.FormUrlencoded && formUrlencoded != null)
                //{
                //    detected = formUrlencoded;
                //}
                else
                {
                    detected = json ?? xml ?? formUrlencoded;
                }
            }

            if (detected == multipartFormData && multipartFormData != null)
            {
                string httpContentDescription;
                if (!Settings.GenerateMultipartFormDataExtensionMethods)
                {
                    httpContentDescription = "Manually add an extension method to support the exact parameters. See https://github.com/canton7/RestEase#wrapping-other-methods for more info.";
                }
                else
                {
                    httpContentDescription = "An extension method is generated to support the exact parameters.";
                    extensionMethodParameterList.AddRange(multipartFormData.Schema.Properties.Select(p => BuildValidParameter(p.Key, p.Value, p.Value.Nullable, p.Value.Description, string.Empty)));
                }

                bodyParameterList.Add(new RestEaseParameter
                {
                    Required = true,
                    Identifier = "content",
                    IdentifierWithType = "HttpContent content",
                    IdentifierWithRestEase = "[Body] HttpContent content",
                    Summary = httpContentDescription,
                    IsSpecial = true
                });

                return new RequestDetails
                {
                    DetectedContentType = detectedMultipartForm,
                    IsExtension = true
                };
            }

            if (detected == octetStream && octetStream != null)
            {
                string httpContentDescription;
                if (!Settings.GenerateApplicationOctetStreamExtensionMethods)
                {
                    httpContentDescription = "Manually add an extension method to support the exact parameters. See https://github.com/canton7/RestEase#wrapping-other-methods for more info.";
                }
                else
                {
                    httpContentDescription = "An extension method is generated to support the exact parameters.";
                    var extensionParameter = BuildValidParameter("file", octetStream.Schema, true, "The content.", null);
                    extensionMethodParameterList.Add(extensionParameter);
                    extensionMethodParameterList.AddRange(octetStream.Schema.Properties.Select(p => BuildValidParameter(p.Key, p.Value, p.Value.Nullable, p.Value.Description, string.Empty)));
                }

                bodyParameterList.Add(new RestEaseParameter
                {
                    Required = true,
                    Identifier = "content",
                    IdentifierWithType = "HttpContent content",
                    IdentifierWithRestEase = "[Body] HttpContent content",
                    Summary = httpContentDescription,
                    IsSpecial = true
                });

                return new RequestDetails
                {
                    DetectedContentType = detectedOctetStream,
                    IsExtension = true
                };
            }

            if (detected == formUrlencoded && formUrlencoded != null)
            {
                string description;
                if (!Settings.GenerateMultipartFormDataExtensionMethods)
                {
                    description = "Manually add an extension method to support the exact parameters.";
                }
                else
                {
                    description = "An extension method is generated to support the exact parameters.";
                    extensionMethodParameterList.AddRange(formUrlencoded.Schema.Properties.Select(p => BuildValidParameter(p.Key, p.Value, p.Value.Nullable, p.Value.Description, string.Empty)));
                }

                bodyParameterList.Add(new RestEaseParameter
                {
                    Required = true,
                    Identifier = "form",
                    IdentifierWithType = "IDictionary<string, object> form",
                    IdentifierWithRestEase = "[Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> form",
                    Summary = description,
                    IsSpecial = true
                });

                return new RequestDetails
                {
                    DetectedContentType = detectedFormUrl,
                    IsExtension = true
                };
            }

            var requestDetails = new RequestDetails();
            if (detected == null)
            {
                detected = supportedOpenApiMediaTypes.First().Value;
                requestDetails.ContentTypes = operation.RequestBody.Content.Keys;
            }
            else
            {
                requestDetails.DetectedContentType = supportedOpenApiMediaTypes.First(s => s.Value == detected).Key;
            }

            string bodyParameter = null;
            switch (detected.Schema?.GetSchemaType())
            {
                case SchemaType.Array:
                    string arrayType = detected.Schema.Items.Reference != null
                        ? detected.Schema.Items.Reference.Id
                        : MapSchema(detected.Schema.Items, null, detected.Schema.Nullable).ToString();
                    bodyParameter = MapArrayType(arrayType);
                    break;

                case SchemaType.Object:
                    bodyParameter = detected.Schema.Reference.Id;
                    break;
            }

            if (!string.IsNullOrEmpty(bodyParameter))
            {
                string bodyParameterIdentifierName = bodyParameter.ToCamelCase();
                bodyParameterList.Add(new RestEaseParameter
                {
                    Required = true,
                    Identifier = bodyParameterIdentifierName,
                    IdentifierWithType = $"{bodyParameter} {bodyParameterIdentifierName}",
                    IdentifierWithRestEase = $"[Body] {bodyParameter} {bodyParameterIdentifierName}",
                    Summary = detected?.Schema?.Description
                });
            }

            return requestDetails;
        }

        private string GeneratedRestEaseMethodName(string path, OpenApiOperation operation, string httpMethodPascalCased)
        {
            string methodRestEaseMethod;
            if (!string.IsNullOrEmpty(operation.OperationId) && char.IsLetter(operation.OperationId[0]))
            {
                methodRestEaseMethod = operation.OperationId.ToPascalCase();
            }
            else
            {
                var list = new List<string> { httpMethodPascalCased };

                bool byFound = false;
                foreach (string part in path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (part.StartsWith("{"))
                    {
                        var text = part.Split(new[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries)[0].ToPascalCase();

                        list.Add(byFound ? $"By{text}" : $"And{text}");

                        byFound = true;
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
            string returnTypeAsString = returnType as string;
            if (returnTypeAsString == null)
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

        private RestEaseParameter BuildValidParameter(string identifier, OpenApiSchema schema, bool required, string description, string parameterType, params string[] extraAttributes)
        {
            var attributes = new List<string>();
            string validIdentifier = CSharpUtils.CreateValidIdentifier(identifier);

            object paramWithType;
            if (identifier != validIdentifier)
            {
                attributes.Add($"Name = \"{identifier}\"");
                attributes.AddRange(extraAttributes);

                paramWithType = MapSchema(schema, validIdentifier, !required, false);

                return new RestEaseParameter
                {
                    Required = required,
                    Identifier = validIdentifier,
                    SchemaType = schema.GetSchemaType(),
                    SchemaFormat = schema.GetSchemaFormat(),
                    IdentifierWithType = $"{paramWithType}",
                    IdentifierWithRestEase = $"[{parameterType}({string.Join(", ", attributes)})] {paramWithType}",
                    Summary = description
                };
            }

            string extraAttributesBetweenParentheses = extraAttributes.Length == 0 ? string.Empty : $"({string.Join(", ", extraAttributes)})";
            paramWithType = MapSchema(schema, identifier, !required, false);

            return new RestEaseParameter
            {
                Required = required,
                Identifier = identifier,
                SchemaType = schema.GetSchemaType(),
                SchemaFormat = schema.GetSchemaFormat(),
                IdentifierWithType = $"{paramWithType}",
                IdentifierWithRestEase = $"[{parameterType}{extraAttributesBetweenParentheses}] {paramWithType}",
                Summary = description
            };
        }

        private bool TryGetOpenApiMediaType(IDictionary<string, OpenApiMediaType> contentTypes, string contentType, out OpenApiMediaType mediaType, out string detectedContentType)
        {
            var contentTypesIgnoreCase = new Dictionary<string, OpenApiMediaType>(contentTypes, StringComparer.InvariantCultureIgnoreCase);

            if (contentTypesIgnoreCase.TryGetValue(contentType, out mediaType))
            {
                detectedContentType = contentType;
                return true;
            }

            var key = contentTypesIgnoreCase.Keys.FirstOrDefault(ct => ct.Contains(contentType));
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

            detectedContentType = null;
            return false;
        }
    }
}