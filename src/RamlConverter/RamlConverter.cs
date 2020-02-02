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

        /// <summary>
        /// Converts the input RAML file to an Open API Specification output file using the provided options.
        /// </summary>
        /// <param name="inputPath">The path to the RAML file.</param>
        /// <param name="outputPath">The path to the generated Open API Specification file.</param>
        /// <param name="specVersion">The Open API specification version.</param>
        /// <param name="format">Open API document format.</param>
        public void ConvertToFile(string inputPath, string outputPath, OpenApiSpecVersion specVersion = OpenApiSpecVersion.OpenApi3_0, OpenApiFormat format = OpenApiFormat.Json)
        {
            var document = ConvertToOpenApiDocument(File.OpenRead(inputPath));

            string contents = _doc.Serialize(specVersion, format);

            File.WriteAllText(outputPath, contents);
        }

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