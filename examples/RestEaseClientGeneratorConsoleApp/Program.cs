using Microsoft.OpenApi.Readers;
using RestEase;
using RestEaseClientGenerator;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGeneratorConsoleApp.Examples.PetStore.Api;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestEaseClientGeneratorConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var generator = new Generator();

            var petStoreSettings = new GeneratorSettings
            {
                ArrayType = ArrayType.ICollection,
                Namespace = "RestEaseClientGeneratorConsoleApp.Examples.PetStore",
                ApiName = "PetStore"
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
                MultipartFormDataFileType = MultipartFormDataFileType.Stream
            };
            foreach (var file in generator.FromStream(File.OpenRead("Examples\\petstore.json"), petStoreJsonSettings, out OpenApiDiagnostic diagnosticPetStore1))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/PetStoreJson/{file.Name}", file.Content);
            }

            foreach (var file in generator.FromStream(File.OpenRead("Examples\\infura.yaml"), "RestEaseClientGeneratorConsoleApp.Examples.Infura", "Infura", out OpenApiDiagnostic diagnosticInfura))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/Infura/{file.Path}/{file.Name}", file.Content);
            }

            OpenApiDiagnostic diagnosticCog;
            foreach (var file in generator.FromStream(File.OpenRead("Examples\\cognitive-services-personalizer.json"), "RestEaseClientGeneratorConsoleApp.Examples.Cog", "Cog", out diagnosticCog))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/Cog/{file.Path}/{file.Name}", file.Content);
            }
            Console.WriteLine(JsonSerializer.Serialize(diagnosticCog));

            foreach (var file in generator.FromStream(File.OpenRead("Examples\\SpeechServices.json"), "RestEaseClientGeneratorConsoleApp.Examples.SpeechServices", "SpeechServices", out var diagnosticSpeech))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/SpeechServices/{file.Path}/{file.Name}", file.Content);
            }

            foreach (var file in generator.FromStream(File.OpenRead("Examples\\FormRecognizer.json"), "RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer", "FormRecognizer", out var diagnosticFormRecognizer))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/FormRecognizer/{file.Path}/{file.Name}", file.Content);
            }

            //foreach (var file in generator.FromStream(File.OpenRead("Examples\\ComputerVision.json"), "RestEaseClientGeneratorConsoleApp.Examples.ComputerVision", "ComputerVision", out var diagnosticComputerVision))
            //{
            //    File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Examples/ComputerVision/{file.Path}/{file.Name}", file.Content);
            //}

            await PetStore();
        }

        private static async Task PetStore()
        {
            var petStoreApi = RestClient.For<IPetStoreApi>("https://petstore.swagger.io/v2");

            var findPetsByTags = await petStoreApi.FindPetsByTagsAsync(new[] { "cat" });
            foreach (var find in findPetsByTags)
            {
                Console.WriteLine(JsonSerializer.Serialize(find));
            }

            var getPetById = await petStoreApi.GetPetByIdAsync(findPetsByTags.First().Id);
            Console.WriteLine(JsonSerializer.Serialize(getPetById));
        }
    }
}