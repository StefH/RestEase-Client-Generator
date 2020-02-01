using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Raml.Parser.Expressions;
using RamlToOpenApiConverter.Extensions;
using SharpYaml.Serialization;

namespace RamlToOpenApiConverter
{
    public class RamlConverter
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        private OpenApiDocument _doc;

        public OpenApiDocument ConvertToOpenApiDocument(Stream stream)
        {
            var serializer = new Serializer();

            var o = serializer.Deserialize<IDictionary<object, object>>(stream);
            var types = o.GetAsDictionary("types");

            _doc = new OpenApiDocument
            {
                Info = MapInfo(o),
                Components = MapComponents(types)
            };

            _doc.Paths = MapPaths(o);

            return _doc;
        }

        private OpenApiComponents MapComponents(IDictionary<object, object> types)
        {
            var components = new OpenApiComponents
            {
                Schemas = new Dictionary<string, OpenApiSchema>()
            };

            if (types != null)
            {
                foreach (var key in types.Keys.OfType<string>())
                {
                    var values = types.GetAsDictionary(key);
                    bool isObject = values?.Get("type") == "object";

                    if (isObject)
                    {
                        components.Schemas.Add(key, MapSchema(values.GetAsDictionary("properties")));
                    }
                }
            }

            return components;
        }

        private OpenApiSchema MapSchema(IDictionary<object, object> properties)
        {
            return new OpenApiSchema
            {
                Type = "object",
                Properties = MapProperties(properties)
            };
        }

        private IDictionary<string, OpenApiSchema> MapProperties(IDictionary<object, object> properties)
        {
            var dictionary = new Dictionary<string, OpenApiSchema>();
            foreach (var key in properties.Keys.OfType<string>())
            {
                OpenApiSchema schema;

                switch (properties[key])
                {
                    case string simple:
                        schema = new OpenApiSchema
                        {
                            Type = simple
                        };
                        break;

                    case IDictionary<object, object> complex:
                        bool isObject = complex.Get("type") == "object";
                        if (isObject)
                        {
                            schema = MapSchema(complex.GetAsDictionary("properties"));
                        }
                        else
                        {
                            // TODO ?
                            schema = new OpenApiSchema
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.Schema,
                                    ExternalResource = "definitions",
                                    Id = key
                                }
                            };
                        }
                        break;

                    default:
                        throw new NotSupportedException();
                }

                dictionary.Add(key, schema);
            }

            return dictionary;
        }

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
                Description = values.Get("description"),
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
                var responses = values.GetAsDictionary(key);
                var body = responses?.GetAsDictionary("body");
                if (body != null)
                {
                    var response = new OpenApiResponse
                    {
                        Content = MapContent(body)
                    };
                    openApiResponses.Add(key.ToString(), response);
                }
                else
                {
                    openApiResponses.Add(key.ToString(), new OpenApiResponse());
                }
            }

            return openApiResponses;
        }

        private IDictionary<string, OpenApiMediaType> MapContent(IDictionary<object, object> values)
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
                    var x = values.GetAsDictionary(key);
                    string typeAsString = x?.Get("type");
                    if (!string.IsNullOrEmpty(typeAsString))
                    {
                        OpenApiSchema openApiSchema;
                        if (typeAsString.StartsWith("{"))
                        {
                            var objectType = JsonConvert.DeserializeObject<ObjectType>(typeAsString, _jsonSerializerSettings);
                            openApiSchema = MapSchema(objectType);
                        }
                        else
                        {
                            var referenceSchemas = typeAsString
                                .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => CreateDummyOpenApiReferenceSchema(o.Trim()))
                                .ToList();

                            if (referenceSchemas.Count == 1)
                            {
                                openApiSchema = referenceSchemas.Single();
                            }
                            else
                            {
                                openApiSchema = new OpenApiSchema
                                {
                                    AnyOf = referenceSchemas
                                };
                            }
                        }

                        var openApiMediaType = new OpenApiMediaType { Schema = openApiSchema };
                        content.Add(key, openApiMediaType);
                    }
                }
            }

            return content;
        }

        private OpenApiSchema CreateDummyOpenApiReferenceSchema(string referenceId)
        {
            return new OpenApiSchema
            {
                Type = "object",
                Reference = new OpenApiReference { Id = referenceId }
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

        private OpenApiInfo MapInfo(IDictionary<object, object> o)
        {
            return new OpenApiInfo
            {
                Title = o.Get("title"),
                Description = o.Get("description"),
                Version = o.Get("version")
            };
        }
    }
}
