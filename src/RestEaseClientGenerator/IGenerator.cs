using Microsoft.OpenApi.Readers;
using System.Collections.Generic;
using System.IO;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGenerator
{
    public interface IGenerator
    {
        ICollection<GeneratedFile> FromStream(Stream stream, GeneratorSettings settings, out OpenApiDiagnostic diagnostic);

        ICollection<GeneratedFile> FromStream(Stream stream, string clientNamespace, string apiName, out OpenApiDiagnostic diagnostic);
    }
}