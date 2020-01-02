using System.IO;
using System.Threading.Tasks;
using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGeneratorConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var generator = new Generator();

            var petStoreOpenApi3Settings = new GeneratorSettings
            {
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi3",
                ApiName = "PetStoreOpenApi3",
                GenerateFormUrlEncodedExtensionMethods = true,
                GenerateMultipartFormDataExtensionMethods = true,
                GenerateApplicationOctetStreamExtensionMethods = true,
                ApplicationOctetStreamType = ApplicationOctetStreamType.Stream
            };
            foreach (var file in generator.FromStream(File.OpenRead("Examples\\petstore-openapi3.json"), petStoreOpenApi3Settings, out OpenApiDiagnostic diagnosticPetStoreOpenApi3))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/PetStoreOpenApi3/{file.Path}/{file.Name}", file.Content);
            }

            var petStoreSettings = new GeneratorSettings
            {
                ArrayType = ArrayType.ICollection,
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.PetStore",
                ApiName = "PetStore",
                ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified = true
            };
            foreach (var file in generator.FromStream(File.OpenRead("Examples\\petstore.yaml"), petStoreSettings, out OpenApiDiagnostic diagnosticPetStore1))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/PetStore/{file.Path}/{file.Name}", file.Content);
            }

            var petStoreJsonSettings = new GeneratorSettings
            {
                SingleFile = true,
                ArrayType = ArrayType.IEnumerable,
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.PetStoreJson",
                ApiName = "PetStoreJson",
                AddAuthorizationHeader = true,
                UseDateTimeOffset = true,
                MethodReturnType = MethodReturnType.Type,
                MultipartFormDataFileType = MultipartFormDataFileType.Stream,
                ApiNamespace = "Test123",
                ModelsNamespace = "Modelz"
            };
            foreach (var file in generator.FromStream(File.OpenRead("Examples\\petstore.json"), petStoreJsonSettings, out OpenApiDiagnostic diagnosticPetStore1))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/PetStoreJson/{file.Name}", file.Content);
            }

            foreach (var file in generator.FromStream(File.OpenRead("Examples\\infura.yaml"), "RestEaseClientGeneratorConsoleApp.Examples.Infura", "Infura", out OpenApiDiagnostic diagnosticInfura))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/Infura/{file.Path}/{file.Name}", file.Content);
            }

            foreach (var file in generator.FromStream(File.OpenRead("Examples\\cognitive-services-personalizer.json"), "RestEaseClientGeneratorConsoleApp.Examples.Cog", "Cog", out var diagnosticCog))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/Cog/{file.Path}/{file.Name}", file.Content);
            }

            foreach (var file in generator.FromStream(File.OpenRead("Examples\\SpeechServices.json"), "RestEaseClientGeneratorConsoleApp.Examples.SpeechServices", "SpeechServices", out var diagnosticSpeech))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/SpeechServices/{file.Path}/{file.Name}", file.Content);
            }

            foreach (var file in generator.FromStream(File.OpenRead("Examples\\FormRecognizer.json"), "RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer", "FormRecognizer", out var diagnosticFormRecognizer))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/FormRecognizer/{file.Path}/{file.Name}", file.Content);
            }

            var computerVisionSettings = new GeneratorSettings
            {
                SingleFile = true,
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.ComputerVision",
                ApiName = "ComputerVision"
            };
            foreach (var file in generator.FromStream(File.OpenRead("Examples\\ComputerVision.json"), computerVisionSettings, out var diagnosticComputerVision))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/ComputerVision/{file.Path}/{file.Name}", file.Content);
            }

            await PetStoreTests.Run();

            await PetStoreOpenApi3ApiTests.Run();
        }
    }
}