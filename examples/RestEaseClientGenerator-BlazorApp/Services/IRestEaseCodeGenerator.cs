using System.IO;
using Microsoft.OpenApi.Readers;

namespace RestEaseClientGeneratorBlazorApp.Services
{
    public interface IRestEaseCodeGenerator
    {
        byte[] GenerateZippedBytesFromString(string content, GeneratorSettings settings, out OpenApiDiagnostic diagnostic);
    }
}