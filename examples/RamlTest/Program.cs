using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.OpenApi.Models;
using SharpYaml.Serialization;

namespace RamlTest
{
    public static class Program
    {
        public static string Get(this IDictionary<object, object> d, string key)
        {
            return d.ContainsKey(key) ? d[key] as string : null;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");



            var se = new SerializerSettings
            {
                //NamingConvention = new IgnoreCasetNamingConvention()
            };

            var serializer = new Serializer(se);

            var o = serializer.Deserialize<IDictionary<object, object>>(File.OpenRead("MediaWiki.raml"));

            int x = 0;

            var doc = new OpenApiDocument
            {
                Info = MapInfo(o),
                Paths = MapPaths(o)
            };

            int y = 9;
        }

        private static OpenApiPaths MapPaths(IDictionary<object, object> o)
        {
            var paths = new OpenApiPaths();

            foreach (var key in o.Keys.OfType<string>().Where(k => k.StartsWith("/")))
            {
                paths.Add(key, MapPathItem(o[key] as IDictionary<object, object>));
            }

            return paths;
        }

        private static OpenApiPathItem MapPathItem(IDictionary<object, object> values)
        {
            return new OpenApiPathItem
            {
                Description = values.Get("description"),
                Parameters = new List<OpenApiParameter>()
            };
        }

        private static OpenApiInfo MapQ(IDictionary<object, object> o)
        {
            return null;
        }

        private static OpenApiInfo MapInfo(IDictionary<object, object> o)
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
