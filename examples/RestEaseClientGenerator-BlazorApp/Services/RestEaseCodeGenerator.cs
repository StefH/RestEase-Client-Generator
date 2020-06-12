using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly IFileZipper _zipper;

        public RestEaseCodeGenerator(IGenerator generator, IFileZipper zipper)
        {
            _generator = generator;
            _zipper = zipper;
        }

        public byte[] GenerateZippedBytesFromString(string content, GeneratorSettings settings, out OpenApiDiagnostic diagnostic)
        {
            //if (Path.GetExtension(path).EndsWith("raml", StringComparison.OrdinalIgnoreCase))
            //{
            //    diagnostic = new OpenApiDiagnostic();
            //    document = new RamlConverter().ConvertToOpenApiDocument(path);
            //}

            var reader = new OpenApiStringReader();
            var document = reader.Read(content, out diagnostic);

            if (diagnostic.Errors.Any())
            {
                var errorMessages = string.Join(" | ", diagnostic.Errors.Select(JsonConvert.SerializeObject));
                Trace.WriteLine($"OpenApi Errors: {errorMessages}");
            }

            ICollection<GeneratedFile> result;
            try
            {
                result = _generator.FromDocument(document, settings, diagnostic.SpecificationVersion);
            }
            catch (Exception e)
            {
                Trace.WriteLine($"FromDocument Error: {e.Message}");
                throw;
            }

            try
            {
                return _zipper.Zip(result);
            }
            catch (Exception e)
            {
                Trace.WriteLine($"Zip Error: {e.Message}");
                throw;
            }
        }
    }
}