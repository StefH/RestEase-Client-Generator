using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                paths.Add(key, MapPathItem(o[key] as IDictionary<object, object>));
            }

            return paths;
        }

        private OpenApiPathItem MapPathItem(IDictionary<object, object> values)
        {
            return new OpenApiPathItem
            {
                Description = values.Get("description"),
                Parameters = new List<OpenApiParameter>(),
                Operations = MapOperations(values)
            };
        }

        private IDictionary<OperationType, OpenApiOperation> MapOperations(IDictionary<object, object> operations)
        {
            var map = new Dictionary<OperationType, OpenApiOperation>();
            foreach (var key in operations.Keys.OfType<string>())
            {
                map.Add(MapOperationType(key), MapOperation(operations[key] as IDictionary<object, object>));
            }

            return map;
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
            var queryParameters = values.GetAsDictionary("queryParameters");
            if (queryParameters != null)
            {
                foreach (string key in queryParameters.Keys.OfType<string>())
                {
                    var parameterDetails = queryParameters.GetAsDictionary(key);

                    // TODO only string?
                    parameters.Add(new OpenApiParameter
                    {
                        In = ParameterLocation.Query,
                        Name = key,
                        Required = parameterDetails?.Get<bool>("required") ?? false,
                        Schema = new OpenApiSchema
                        {
                            Type = "string"
                        }
                    });
                }
            }

            return parameters;
        }

        private OpenApiResponses MapResponses(IDictionary<object, object> values)
        {
            var responses = new OpenApiResponses();

            foreach (object key in values.Keys)
            {
                switch (key)
                {
                    case int intValue:
                        var x = values.GetAsDictionary(key);
                        var body = x?.GetAsDictionary("body");
                        if (body != null)
                        {
                            var response = new OpenApiResponse
                            {
                                Content = MapContent(body)
                            };
                            responses.Add(intValue.ToString(), response);
                        }
                        else
                        {
                            responses.Add(intValue.ToString(), new OpenApiResponse());
                        }

                        break;
                }
            }

            return responses;
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
                                .Select(o => CreateOpenApiReferenceSchema(o.Trim()))
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

        private OpenApiSchema CreateOpenApiReferenceSchema(string referenceId)
        {
            return new OpenApiSchema
            {
                Type = "object",
                Reference = new OpenApiReference { Id = referenceId }
            };
        }

        private OpenApiMediaType MapMediaTypeFromJson(string json)
        {
            var objectType = JsonConvert.DeserializeObject<ObjectType>(json, _jsonSerializerSettings);
            return new OpenApiMediaType
            {
                Schema = MapSchema(objectType)
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

        private OperationType MapOperationType(string value)
        {
            switch (value)
            {
                case "get":
                    return OperationType.Get;

                case "put":
                    return OperationType.Put;

                case "post":
                    return OperationType.Post;

                case "delete":
                    return OperationType.Delete;

                case "options":
                    return OperationType.Options;

                case "head":
                    return OperationType.Head;

                case "patch":
                    return OperationType.Patch;

                case "trace":
                    return OperationType.Trace;

            }

            throw new NotSupportedException();
        }

        private OpenApiInfo MapQ(IDictionary<object, object> o)
        {
            return null;
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
