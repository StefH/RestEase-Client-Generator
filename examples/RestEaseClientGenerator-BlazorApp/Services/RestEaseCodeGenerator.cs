using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.OpenApi.Readers;
using Newtonsoft.Json;
using RestEaseClientGenerator;
using RestEaseClientGenerator.Models;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGeneratorBlazorApp.Services
{
    internal class RestEaseCodeGenerator : IRestEaseCodeGenerator
    {
        private readonly IGenerator _generator;

        public RestEaseCodeGenerator(IGenerator generator)
        {
            _generator = generator;
        }

        public ICollection<GeneratedFile> GenerateFromStream(Stream stream, GeneratorSettings settings, out OpenApiDiagnostic diagnostic)
        {
            var reader = new OpenApiStreamReader();
            var document = reader.Read(stream, out diagnostic);

            var result = _generator.FromDocument(document, settings, diagnostic.SpecificationVersion);
            if (diagnostic.Errors.Any())
            {
                var errorMessages = string.Join(" | ", diagnostic.Errors.Select(JsonConvert.SerializeObject));
                Trace.WriteLine($"OpenApi Errors: {errorMessages}");
            }

            return result;
        }
    }
}