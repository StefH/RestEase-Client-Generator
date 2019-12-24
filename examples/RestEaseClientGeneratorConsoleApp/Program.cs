using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.OpenApi.Readers;
using RestEase;
using RestEaseClientGenerator;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGeneratorConsoleApp.PetStore.Api;

namespace RestEaseClientGeneratorConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var generator = new Generator();

            var petStoreSettings = new GeneratorSettings
            {
                ArrayType = ArrayType.IEnumerable,
                Namespace = "RestEaseClientGeneratorConsoleApp.PetStore",
                ApiName = "PetStore"
            };
            foreach (var file in generator.FromStream(File.OpenRead("petstore.yaml"), petStoreSettings, out OpenApiDiagnostic diagnosticPetStore1))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/PetStore/{file.Path}/{file.Name}", file.Content);
            }

            var petStoreJsonSettings = new GeneratorSettings
            {
                SingleFile = true,
                ArrayType = ArrayType.IEnumerable,
                Namespace = "RestEaseClientGeneratorConsoleApp.PetStoreJson",
                ApiName = "PetStoreJson"
            };
            foreach (var file in generator.FromStream(File.OpenRead("petstore.json"), petStoreJsonSettings, out OpenApiDiagnostic diagnosticPetStore1))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/PetStoreJson/{file.Name}", file.Content);
            }

            foreach (var file in generator.FromStream(File.OpenRead("infura.yaml"), "RestEaseClientGeneratorConsoleApp.Infura", "Infura", out OpenApiDiagnostic diagnosticPetStore1))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Infura/{file.Path}/{file.Name}", file.Content);
            }

            foreach (var file in generator.FromStream(File.OpenRead("cognitive-services-personalizer.json"), "RestEaseClientGeneratorConsoleApp.Cog", "Cog", out OpenApiDiagnostic diagnosticPetStore1))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/Cog/{file.Path}/{file.Name}", file.Content);
            }

            await PetStore();
        }

        private static async Task PetStore()
        {
            var petStoreApi = RestClient.For<IPetStoreApi>("https://petstore.swagger.io/v2");

            var getPetById = await petStoreApi.GetPetByIdAsync(2);
            Console.WriteLine(JsonSerializer.Serialize(getPetById));

            var findPetsByTags = await petStoreApi.FindPetsByTagsAsync(new[] { "cat" });
            foreach (var find in findPetsByTags)
            {
                Console.WriteLine(JsonSerializer.Serialize(find));
            }
        }
    }
}