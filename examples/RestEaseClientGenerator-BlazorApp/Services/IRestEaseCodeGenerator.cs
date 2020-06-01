using System.IO;
using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGeneratorBlazorApp.Services
{
    public interface IRestEaseCodeGenerator
    {
        byte[] GenerateZippedBytesFromInputStream(Stream stream, GeneratorSettings settings, out OpenApiDiagnostic diagnostic);
    }
}