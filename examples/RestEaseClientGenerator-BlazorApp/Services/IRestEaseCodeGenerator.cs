using System.Collections.Generic;
using System.IO;
using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator.Models;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGeneratorBlazorApp.Services
{
    public interface IRestEaseCodeGenerator
    {
        ICollection<GeneratedFile> GenerateFromStream(Stream stream, GeneratorSettings settings, out OpenApiDiagnostic diagnostic);
    }
}