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

        private OpenApiSchema MapProperty(IDictionary<object, object> values)
        {
            bool required = values.Get<bool?>("required") == true;
            string type = values.Get("type");
            string format = values.Get("format");

            if (type == "datetime")
            {
                type = "string";
                format = "date-time";
            }

            return new OpenApiSchema
            {
                Type = type,
                Format = format,
                Nullable = !required,
                Description = values.Get("description"),
                Minimum = values.Get<decimal?>("minimum"),
                Maximum = values.Get<decimal?>("maximum"),
                MaxLength = values.Get<int?>("maxLength"),
                MinLength = values.Get<int?>("minLength")
            };
        }

        private IDictionary<string, OpenApiSchema> MapProperties(IDictionary<object, object> properties)
        {
            var openApiProperties = new Dictionary<string, OpenApiSchema>();
            foreach (var key in properties.Keys.OfType<string>())
            {
                OpenApiSchema schema;

                IDictionary<object, object> values;
                switch (properties[key])
                {
                    case string stringValue:
                        values = new Dictionary<object, object>();
                        values.Add("type", stringValue);
                        values.Add("properties", new Dictionary<object, object>());
                        break;

                    case IDictionary<object, object> complex:
                        values = complex;
                        break;

                    default:
                        throw new NotSupportedException();
                }

                string propertyType = values.Get("type");
                if (propertyType == "object")
                {
                    // Object
                    schema = MapSchema(values.GetAsDictionary("properties"));
                }
                else if (_types.ContainsKey(propertyType))
                {
                    // Simple Type
                    var simpleType = _types.GetAsDictionary(propertyType);
                    schema = MapProperty(simpleType);
                }
                else
                {
                    // Normal property
                    schema = MapProperty(values);
                }


                //switch (properties[key])
                //{
                //    case string primitive:
                //        schema = new OpenApiSchema
                //        {
                //            Type = primitive
                //        };
                //        break;

                //    case IDictionary<object, object> complex:
                //        string propertyType = complex.Get("type");
                //        bool isObject = propertyType == "object";
                //        if (isObject)
                //        {
                //            schema = MapSchema(complex.GetAsDictionary("properties"));
                //        }
                //        else if (_types.ContainsKey(propertyType))
                //        {
                //            var simpleType = _types.GetAsDictionary(propertyType);

                //            string type = simpleType.Get("type");
                //            string format = simpleType.Get("format");

                //            if (type == "datetime")
                //            {
                //                type = "string";
                //                format = "date-time";
                //            }

                //            schema = new OpenApiSchema
                //            {
                //                Description = simpleType.Get("description"),
                //                Format = format,
                //                Minimum = simpleType.Get<decimal?>("minimum"),
                //                Maximum = simpleType.Get<decimal?>("maximum"),
                //                MaxLength = simpleType.Get<int?>("maxLength"),
                //                MinLength = simpleType.Get<int?>("minLength"),
                //                Type = type
                //            };
                //        }
                //        else
                //        {
                //            // TODO ?
                //            schema = new OpenApiSchema
                //            {
                //                Reference = new OpenApiReference
                //                {
                //                    Type = ReferenceType.Schema,
                //                    ExternalResource = "definitions",
                //                    Id = key
                //                }
                //            };
                //        }
                //        break;

                //    default:
                //        throw new NotSupportedException();
                //}

                openApiProperties.Add(key, schema);
            }

            return openApiProperties;
        }
    }
}