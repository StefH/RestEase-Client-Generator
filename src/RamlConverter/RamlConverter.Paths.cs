using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Raml.Parser.Expressions;
using RamlToOpenApiConverter.Extensions;

namespace RamlToOpenApiConverter
{
    public partial class RamlConverter
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        private OpenApiPaths MapPaths(IDictionary<object, object> o)
        {
            var paths = new OpenApiPaths();

            foreach (var key in o.Keys.OfType<string>().Where(k => k.StartsWith("/")))
            {
                var pathItem = MapPathItem(key, new List<OpenApiParameter>(), o.GetAsDictionary(key));
                paths.Add(pathItem.AdjustedPath, pathItem.Item);
            }

            return paths;
        }

        private (OpenApiPathItem Item, string AdjustedPath) MapPathItem(string parent, IList<OpenApiParameter> parentParameters, IDictionary<object, object> values)
        {
            var operations = new Dictionary<OperationType, OpenApiOperation>();

            foreach (string key in values.Keys.OfType<string>())
            {
                if (key.StartsWith("/"))
                {
                    var d = values.GetAsDictionary(key);
                    return MapPathItem($"{parent}{key}", MapParameters(d), d);
                }

                if (TryMapOperationType(key, out OperationType operationType))
                {
                    var operation = MapOperation(values.GetAsDictionary(key));
                    foreach (var parameter in parentParameters)
                    {
                        operation.Parameters.Add(parameter);
                    }

                    operations.Add(operationType, operation);
                }
            }

            return (new OpenApiPathItem
            {
                Parameters = MapParameters(values),
                Operations = operations
            }, parent);
        }

        private OpenApiOperation MapOperation(IDictionary<object, object> values)
        {
            return new OpenApiOperation
            {
                Description = values.Get("description"),
                Responses = MapResponses(values.GetAsDictionary("responses")),
                Parameters = MapParameters(values),
            };
        }

        private IList<OpenApiParameter> MapParameters(IDictionary<object, object> values)
        {
            var parameters = new List<OpenApiParameter>();

            parameters.AddRange(MapParameters(values.GetAsDictionary("queryParameters"), ParameterLocation.Query));
            parameters.AddRange(MapParameters(values.GetAsDictionary("uriParameters"), ParameterLocation.Path));
            parameters.AddRange(MapParameters(values.GetAsDictionary("headers"), ParameterLocation.Header));

            return parameters;
        }

        private IList<OpenApiParameter> MapParameters(IDictionary<object, object> parameters, ParameterLocation parameterLocation)
        {
            var openApiParameters = new List<OpenApiParameter>();

            if (parameters == null)
            {
                return openApiParameters;
            }

            foreach (string key in parameters.Keys.OfType<string>())
            {
                var parameterDetails = parameters.GetAsDictionary(key);

                // TODO only string?
                openApiParameters.Add(new OpenApiParameter
                {
                    In = parameterLocation,
                    Name = key,
                    Required = parameterDetails?.Get<bool>("required") ?? false,
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    }
                });
            }

            return openApiParameters;
        }

        private OpenApiResponses MapResponses(IDictionary<object, object> values)
        {
            var openApiResponses = new OpenApiResponses();

            foreach (int key in values.Keys.OfType<int>())
            {
                var response = values.GetAsDictionary(key);
                var body = response?.GetAsDictionary("body");
                string description = response?.Get("description");
                if (body != null)
                {
                    var openApiResponse = new OpenApiResponse
                    {
                        Description = description,
                        Content = MapContents(body)
                    };
                    openApiResponses.Add(key.ToString(), openApiResponse);
                }
                else
                {
                    openApiResponses.Add(key.ToString(), new OpenApiResponse
                    {
                        Description = description
                    });
                }
            }

            return openApiResponses;
        }

        private IDictionary<string, OpenApiMediaType> MapContents(IDictionary<object, object> values)
        {
            if (values == null)
            {
                return null;
            }

            var content = new Dictionary<string, OpenApiMediaType>();

            foreach (string key in new[] { "application/json", "application/xml" })
            {
                if (values.ContainsKey(key))
                {
                    var items = values.GetAsDictionary(key); // Body and Example
                    string type = items?.Get("type");
                    string exampleAsJson = items?.Get("example");

                    var openApiMediaType = new OpenApiMediaType
                    {
                        Schema = !string.IsNullOrEmpty(type) ? MapMediaTypeSchema(type) : null,
                        Example = !string.IsNullOrEmpty(exampleAsJson) ? MapExample(exampleAsJson) : null,
                    };

                    content.Add(key, openApiMediaType);
                }
            }

            return content;
        }

        private IOpenApiAny MapExample(string exampleAsJson)
        {
            var stringAsStream = new MemoryStream(Encoding.UTF8.GetBytes(exampleAsJson));

            var reader = new OpenApiStreamReader();
            return reader.ReadFragment<IOpenApiAny>(stringAsStream, OpenApiSpecVersion.OpenApi3_0, out var _);
        }

        private OpenApiSchema MapMediaTypeSchema(string typeAsString)
        {
            if (typeAsString.StartsWith("{"))
            {
                var objectType = JsonConvert.DeserializeObject<ObjectType>(typeAsString, _jsonSerializerSettings);
                return MapSchema(objectType);
            }

            var referenceSchemas = typeAsString
                .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(o => CreateDummyOpenApiReferenceSchema(o.Trim()))
                .ToList();

            if (referenceSchemas.Count == 1)
            {
                return referenceSchemas.Single();
            }

            return new OpenApiSchema
            {
                AnyOf = referenceSchemas
            };
        }

        private OpenApiSchema CreateDummyOpenApiReferenceSchema(string referenceId)
        {
            return new OpenApiSchema
            {
                Type = "object",
                Reference = new OpenApiReference { Id = referenceId, Type = ReferenceType.Schema }
            };
        }

        private OpenApiSchema MapSchema(ObjectType o)
        {
            return new OpenApiSchema
            {
                Properties = MapProperties(o.Properties)
            };
        }

        private IDictionary<string, OpenApiSchema> MapProperties(IDictionary<string, RamlType> properties)
        {
            return properties.ToDictionary(property => property.Key, property => MapProperty(property.Value));
        }

        private OpenApiSchema MapProperty(RamlType property)
        {
            return new OpenApiSchema
            {
                Type = property.Type,
                Nullable = !property.Required,
                Description = property.Description
            };
        }

        private bool TryMapOperationType(string value, out OperationType operationType)
        {
            foreach (OperationType @enum in Enum.GetValues(typeof(OperationType)))
            {
                if (@enum.GetDisplayName().Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    operationType = @enum;
                    return true;
                }
            }

            operationType = OperationType.Get;
            return false;
        }
    }
}