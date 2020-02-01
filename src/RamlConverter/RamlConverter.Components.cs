using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using RamlToOpenApiConverter.Extensions;

namespace RamlToOpenApiConverter
{
    public partial class RamlConverter
    {
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
            var openApiProperties = new Dictionary<string, OpenApiSchema>();
            foreach (var key in properties.Keys.OfType<string>())
            {
                OpenApiSchema schema;

                switch (properties[key])
                {
                    case string primitive:
                        schema = new OpenApiSchema
                        {
                            Type = primitive
                        };
                        break;

                    case IDictionary<object, object> complex:
                        string propertyType = complex.Get("type");
                        bool isObject = propertyType == "object";
                        if (isObject)
                        {
                            schema = MapSchema(complex.GetAsDictionary("properties"));
                        }
                        else if (_types.ContainsKey(propertyType))
                        {
                            var simpleType = _types.GetAsDictionary(propertyType);

                            schema = new OpenApiSchema
                            {
                                Description = simpleType.Get("description"),
                                Format = simpleType.Get("format"),
                                Minimum = simpleType.Get<decimal?>("minimum"),
                                Maximum = simpleType.Get<decimal?>("maximum"),
                                MaxLength = simpleType.Get<int?>("maxLength"),
                                MinLength = simpleType.Get<int?>("minLength"),
                                Type = simpleType.Get("type")
                            };
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

                openApiProperties.Add(key, schema);
            }

            return openApiProperties;
        }
    }
}