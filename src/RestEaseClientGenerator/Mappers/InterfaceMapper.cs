using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Constants;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Mappers
{
    internal class InterfaceMapper : BaseMapper
    {
        public InterfaceMapper(GeneratorSettings settings) : base(settings)
        {
        }

        public RestEaseInterface Map(OpenApiPaths paths)
        {
            string name = CSharpUtils.CreateValidIdentifier(Settings.ApiName, CasingType.Pascal);

            var methods = paths.Select(p => MapPath(p.Key, p.Value)).SelectMany(x => x).ToList();

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

            return new RestEaseInterface
            {
                Name = $"I{name}Api",
                Namespace = Settings.Namespace,
                Methods = methods
            };
        }

        private IEnumerable<RestEaseInterfaceMethodDetails> MapPath(string path, OpenApiPathItem pathItem)
        {
            return pathItem.Operations.Select(o => MapOperationToMappingModel(path, o.Key.ToString(), o.Value));
        }

        private RestEaseInterfaceMethodDetails MapOperationToMappingModel(string path, string httpMethod, OpenApiOperation operation)
        {
            string methodRestEaseForAnnotation = httpMethod.ToPascalCase();
            string methodRestEaseMethod = !string.IsNullOrEmpty(operation.OperationId) ?
                operation.OperationId.ToPascalCase() :
                GenerateNameForMethod(path, methodRestEaseForAnnotation);

            var pathParameterList = operation.Parameters
                .Where(p => p.In == ParameterLocation.Path && p.Schema.GetSchemaType() != SchemaType.Object)
                .Select(p => BuildValidParameter(p.Name, p.Schema, p.Required, p.Description, "Path"))
                .ToList();

            var queryParameterList = operation.Parameters
                .Where(p => p.In == ParameterLocation.Query && p.Schema.GetSchemaType() != SchemaType.Object)
                .Select(p => BuildValidParameter(p.Name, p.Schema, p.Required, p.Description, "Query"))
                .ToList();

            var bodyParameterList = new List<(string Identifier, string Text, string Summary)>();
            if (operation.RequestBody != null)
            {
                if (TryGetOpenApiMediaType(operation.RequestBody.Content, SupportedContentTypes.ApplicationJson, out OpenApiMediaType requestMediaTypeJson))
                {
                    string bodyParameter;
                    switch (requestMediaTypeJson.Schema?.GetSchemaType())
                    {
                        case SchemaType.Array:
                            string arrayType = requestMediaTypeJson.Schema.Items.Reference != null ? requestMediaTypeJson.Schema.Items.Reference.Id : MapSchema(requestMediaTypeJson.Schema.Items, "", requestMediaTypeJson.Schema.Nullable).ToString();
                            bodyParameter = MapArrayType(arrayType);
                            break;

                        case SchemaType.Object:
                            bodyParameter = requestMediaTypeJson.Schema.Reference.Id;
                            break;

                        default:
                            bodyParameter = "";
                            break;
                    }

                    if (!string.IsNullOrEmpty(bodyParameter))
                    {
                        string bodyParameterIdentifierName = bodyParameter.ToCamelCase();
                        bodyParameterList.Add((bodyParameterIdentifierName, $"[Body] {bodyParameter} {bodyParameterIdentifierName}", requestMediaTypeJson.Schema?.Description));
                    }
                }
                else if (TryGetOpenApiMediaType(operation.RequestBody.Content, SupportedContentTypes.MultipartFormData, out OpenApiMediaType requestMultipartFormData))
                {
                    string httpContentDescription = "Add an extension method to support the exact parameters. See https://github.com/canton7/RestEase#wrapping-other-methods for more info.";
                    bodyParameterList.Add(("content", "HttpContent content", httpContentDescription)); // requestMultipartFormData.Schema?.Description
                }
                else if (TryGetOpenApiMediaType(operation.RequestBody.Content, SupportedContentTypes.ApplicationFormUrlEncoded, out OpenApiMediaType requestFormUrlencoded))
                {
                    bodyParameterList.Add(("formData", "[Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> formData", requestFormUrlencoded.Schema?.Description));
                }
            }

            var methodParameterList = pathParameterList
                .Union(bodyParameterList)
                .Union(queryParameterList)
                .ToList();

            var response = operation.Responses.First();

            object returnType = null;
            if (response.Value != null && TryGetOpenApiMediaType(response.Value.Content, SupportedContentTypes.ApplicationJson, out OpenApiMediaType responseMediaType))
            {
                switch (responseMediaType.Schema?.GetSchemaType())
                {
                    case SchemaType.Array:
                        string arrayType = responseMediaType.Schema.Items.Reference != null ?
                            responseMediaType.Schema.Items.Reference.Id :
                            MapSchema(responseMediaType.Schema.Items, "", responseMediaType.Schema.Nullable).ToString();

                        returnType = MapArrayType(arrayType);
                        break;

                    case SchemaType.Object:
                        returnType = responseMediaType.Schema.Reference != null ?
                            responseMediaType.Schema.Reference.Id :
                            MapSchema(responseMediaType.Schema.AdditionalProperties, "", responseMediaType.Schema.AdditionalProperties.Nullable, false);
                        break;
                }
            }

            var summaryParameters = methodParameterList.Select(mp => $"<param name=\"{mp.Identifier}\">{mp.Summary}</param>").ToList();

            var method = new RestEaseInterfaceMethodDetails
            {
                Summary = operation.Summary ?? $"{methodRestEaseMethod} ({path})",
                SummaryParameters = summaryParameters,
                RestEaseAttribute = $"[{methodRestEaseForAnnotation}(\"{path}\")]",
                RestEaseMethod = new RestEaseInterfaceMethod
                {
                    ReturnType = MapReturnType(returnType),
                    Name = methodRestEaseMethod,
                    Parameters = string.Join(", ", methodParameterList.Select(mp => mp.Text))
                }
            };

            return method;
        }

        private string MapReturnType(object returnType)
        {
            if (returnType == null)
            {
                return "Task";
            }

            switch (Settings.MethodReturnType)
            {
                case MethodReturnType.String:
                    return "Task<string>";

                case MethodReturnType.HttpResponseMessage:
                    return "Task<HttpResponseMessage>";

                case MethodReturnType.Response:
                    return $"Task<Response<{returnType}>>";

                case MethodReturnType.Stream:
                    return "Task<Stream>";

                default:
                    return $"Task<{returnType}>";
            }
        }

        private string GenerateNameForMethod(string path, string httpMethodPascalCased)
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

            return string.Join("", list);
        }

        private (string Identifier, string Text, string Summary) BuildValidParameter(string identifier, OpenApiSchema schema, bool required, string description, string parameterType, params string[] extraAttributes)
        {
            var attributes = new List<string>(extraAttributes);
            string validIdentifier = CSharpUtils.CreateValidIdentifier(identifier);

            if (identifier != validIdentifier)
            {
                attributes.Add($"Name = \"{identifier}\"");

                return (
                    validIdentifier,
                    $"[{parameterType}({string.Join(", ", attributes)}] {MapSchema(schema, validIdentifier, !required, false)}",
                    description
                );
            }

            string attributesBetweenParentheses = attributes.Count == 0 ? string.Empty : $"({string.Join(", ", attributes)})";

            return (
                identifier,
                $"[{parameterType}{attributesBetweenParentheses}] {MapSchema(schema, identifier, !required, false)}",
                description
            );
        }

        private bool TryGetOpenApiMediaType(IDictionary<string, OpenApiMediaType> contentTypes, string contentType, out OpenApiMediaType mediaType)
        {
            var contentTypesIgnoreCase = new Dictionary<string, OpenApiMediaType>(contentTypes, StringComparer.InvariantCultureIgnoreCase);

            if (contentTypesIgnoreCase.TryGetValue(contentType, out mediaType))
            {
                return true;
            }

            var key = contentTypesIgnoreCase.Keys.FirstOrDefault(ct => ct.Contains(contentType));
            if (key != null)
            {
                mediaType = contentTypesIgnoreCase[key];
                return true;
            }

            //if (contentTypesIgnoreCase.Count > 0)
            //{
            //    mediaType = contentTypesIgnoreCase.First().Value;
            //    return true;
            //}

            return false;
        }
    }
}