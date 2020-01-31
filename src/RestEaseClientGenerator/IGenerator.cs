using System.Collections.Generic;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator.Models;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGenerator
{
    public interface IGenerator
    {
        ICollection<GeneratedFile> FromDocument(OpenApiDocument document, GeneratorSettings settings, OpenApiSpecVersion openApiSpecVersion = OpenApiSpecVersion.OpenApi2_0);

        ICollection<GeneratedFile> FromFile(string path, GeneratorSettings settings, out OpenApiDiagnostic diagnostic);

        //ICollection<GeneratedFile> FromStream(Stream stream, GeneratorSettings settings, out OpenApiDiagnostic diagnostic);

        //ICollection<GeneratedFile> FromStream(Stream stream, string clientNamespace, string apiName, bool singleFile, out OpenApiDiagnostic diagnostic);
    }
}