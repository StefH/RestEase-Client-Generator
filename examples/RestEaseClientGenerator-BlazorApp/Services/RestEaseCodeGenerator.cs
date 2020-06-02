using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.OpenApi.Readers;
using Newtonsoft.Json;
using RestEaseClientGenerator;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGeneratorBlazorApp.Services
{
    internal class RestEaseCodeGenerator : IRestEaseCodeGenerator
    {
        private readonly IGenerator _generator;
        private readonly IFileZipper _zipper;

        public RestEaseCodeGenerator(IGenerator generator, IFileZipper zipper)
        {
            _generator = generator;
            _zipper = zipper;
        }

        public byte[]? GenerateZippedBytesFromInputStream(Stream stream, GeneratorSettings settings, out OpenApiDiagnostic diagnostic)
        {
            var reader = new OpenApiStreamReader();
            var document = reader.Read(stream, out diagnostic);

            if (diagnostic.Errors.Any())
            {
                var errorMessages = string.Join(" | ", diagnostic.Errors.Select(JsonConvert.SerializeObject));
                Trace.WriteLine($"OpenApi Errors: {errorMessages}");
            }

            var result = _generator.FromDocument(document, settings, diagnostic.SpecificationVersion);
            return _zipper.Zip(result);
        }
    }
}