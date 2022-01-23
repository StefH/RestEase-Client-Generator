using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGeneratorBlazorApp.Services
{
    public interface IRestEaseCodeGenerator
    {
        byte[] GenerateZippedBytesFromString(string content, GeneratorSettings settings, out OpenApiDiagnostic diagnostic);
    }
}