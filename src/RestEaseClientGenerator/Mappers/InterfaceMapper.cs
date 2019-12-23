using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
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
                Name = $"I{Settings.ApiName}Api",
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
                .Select(p => BuildQueryParameter(p, "Path"))
                .ToList();

            var queryParameterList = operation.Parameters
                .Where(p => p.In == ParameterLocation.Query && p.Schema.GetSchemaType() != SchemaType.Object)
                .Select(p => BuildQueryParameter(p, "Query"))
                .ToList();

            var bodyParameterList = new List<(string Identifier, string Text, string Summary)>();
            if (operation.RequestBody != null && TryGetOpenApiMediaType(operation.RequestBody.Content, out OpenApiMediaType requestMediaType))
            {
                string bodyParameter;
                switch (requestMediaType.Schema?.GetSchemaType())
                {
                    case SchemaType.Array:
                        string arrayType = requestMediaType.Schema.Items.Reference != null ? requestMediaType.Schema.Items.Reference.Id : MapSchema(requestMediaType.Schema.Items, "", requestMediaType.Schema.Nullable).ToString();
                        bodyParameter = $"{arrayType}[]";
                        break;

                    case SchemaType.Object:
                        bodyParameter = requestMediaType.Schema.Reference.Id;
                        break;

                    default:
                        bodyParameter = "";
                        break;
                }

                if (!string.IsNullOrEmpty(bodyParameter))
                {
                    string bodyParameterIdentifierName = bodyParameter.ToCamelCase();
                    bodyParameterList.Add((bodyParameterIdentifierName, $"[Body] {bodyParameter} {bodyParameterIdentifierName}", requestMediaType.Schema?.Description));
                }
            }

            var methodParameterList = pathParameterList
                .Union(bodyParameterList)
                .Union(queryParameterList)
                .ToList();

            var response = operation.Responses.First();

            string returnType = "";
            if (response.Value != null && TryGetOpenApiMediaType(response.Value.Content, out OpenApiMediaType responseMediaType))
            {
                switch (responseMediaType.Schema?.GetSchemaType())
                {
                    case SchemaType.Array:
                        string arrayType = responseMediaType.Schema.Items.Reference != null ?
                            responseMediaType.Schema.Items.Reference.Id :
                            MapSchema(responseMediaType.Schema.Items, "", responseMediaType.Schema.Nullable).ToString();
                        returnType = $"<{arrayType}[]>";
                        break;

                    case SchemaType.Object:
                        returnType = responseMediaType.Schema.Reference != null ?
                            $"<{responseMediaType.Schema.Reference.Id}>" :
                            $"<{MapSchema(responseMediaType.Schema.AdditionalProperties, "", responseMediaType.Schema.AdditionalProperties.Nullable, false)}>";
                        break;
                }
            }

            var summaryParameters = methodParameterList.Select(mp => $"<param name=\"{mp.Identifier}\">{mp.Summary}</param>").ToList();

            var method = new RestEaseInterfaceMethodDetails
            {
                Summary = operation.Summary ?? $"{methodRestEaseMethod} (endpoint{path})",
                SummaryParameters = summaryParameters,
                RestEaseAttribute = $"[{methodRestEaseForAnnotation}(\"{{endpoint}}{path}\")]",
                RestEaseMethod = new RestEaseInterfaceMethod
                {
                    ReturnType = returnType,
                    Name = methodRestEaseMethod,
                    Parameters = string.Join(", ", methodParameterList.Select(mp => mp.Text))
                }
            };

            return method;
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

        private (string Identifier, string Text, string Summary) BuildQueryParameter(OpenApiParameter parameter, string parameterType)
        {
            string identifier = parameter.Name;
            string validIdentifier = CSharpUtils.CreateValidIdentifier(identifier);

            if (identifier != validIdentifier)
            {
                return (
                    validIdentifier,
                    $"[{parameterType}(Name = \"{identifier}\")] {MapSchema(parameter.Schema, validIdentifier, !parameter.Required, false)}",
                    parameter.Description
                );
            }

            return (
                identifier,
                $"[{parameterType}] {MapSchema(parameter.Schema, identifier, !parameter.Required, false)}",
                parameter.Description
            );
        }

        private bool TryGetOpenApiMediaType(IDictionary<string, OpenApiMediaType> content, out OpenApiMediaType mediaType)
        {
            if (content.TryGetValue("application/json", out mediaType))
            {
                return true;
            }

            var jsonKey = content.Keys.FirstOrDefault(key => key.Contains("application/json"));
            if (jsonKey != null)
            {
                mediaType = content[jsonKey];
                return true;
            }

            if (content.Count > 0)
            {
                mediaType = content.First().Value;
                return true;
            }

            return false;
        }
    }
}