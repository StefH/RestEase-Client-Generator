using System.Collections.Generic;
using System.IO;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using RamlToOpenApiConverter.Extensions;
using SharpYaml.Serialization;

namespace RamlToOpenApiConverter
{
    public partial class RamlConverter
    {
        private OpenApiDocument _doc;
        private IDictionary<object, object> _types;

        public OpenApiDocument ConvertToOpenApiDocument(Stream stream)
        {
            var serializer = new Serializer();

            var result = serializer.Deserialize<IDictionary<object, object>>(stream);

            // Step 1 - Get all types
            _types = result.GetAsDictionary("types");

            // Step 2 - Get Info and Components
            _doc = new OpenApiDocument
            {
                Info = MapInfo(result),
                Servers = MapServers(result),
                Components = MapComponents(_types)
            };

            // Step 3 - Get Paths
            _doc.Paths = MapPaths(result);

            // Check if valid
            var text = _doc.Serialize(OpenApiSpecVersion.OpenApi3_0, OpenApiFormat.Json);

            return _doc;
        }
    }
}
