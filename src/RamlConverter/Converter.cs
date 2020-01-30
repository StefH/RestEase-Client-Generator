using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using RamlConverter.Extensions;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Types;
using SharpYaml.Serialization;
using EnumExtensions = RestEaseClientGenerator.Extensions.EnumExtensions;

namespace RamlTest
{
    public class Converter
    {
        public OpenApiDocument Map(Stream stream)
        {
            var serializer = new Serializer();

            var o = serializer.Deserialize<IDictionary<object, object>>(stream);

            var doc = new OpenApiDocument
            {
                Info = MapInfo(o),
                Paths = MapPaths(o)
            };

            return doc;
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
            //r.Match("200:").Groups["statuscode"].Value

            return new OpenApiOperation
            {
                Description = values.Get("description"),
                Responses = MapResponses(values["responses"] as IDictionary<object, object>)
            };
        }

        private OpenApiResponses MapResponses(IDictionary<object, object> values)
        {
            var responses = new OpenApiResponses();

            foreach (var key in values.Keys)
            {
                var x = values[key] as IDictionary<object, object>;
                switch (key)
                {
                    case int intValue:
                        var body = x != null && x.ContainsKey("body") ? x["body"] as IDictionary<object, object> : null;
                        
                        var response = new OpenApiResponse
                        {
                            //Description = values.Get("description"),
                            Content = MapContent(body)
                        };
                        responses.Add(intValue.ToString(), response);
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

            var c = new Dictionary<string, OpenApiMediaType>();

            foreach (SupportedContentType supportedContentType in Enum.GetValues(typeof(SupportedContentType)))
            {
                string key = supportedContentType.GetDescription();
                if (values.ContainsKey(key))
                {
                    var x = (IDictionary<object, object>) values[key];

                    if (x.TryGetValue("type", out object o))
                    {
                        c.Add(key, MapMediaType(x));
                    }
                    
                }
            }


            return c;
        }

        private OpenApiMediaType MapMediaType(IDictionary<object, object> m)
        {
            return new OpenApiMediaType
            {
                //Schema = MapSchema()
            };
        }

        private OpenApiSchema MapSchema(string x)
        {
            return new OpenApiSchema
            {
                
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
