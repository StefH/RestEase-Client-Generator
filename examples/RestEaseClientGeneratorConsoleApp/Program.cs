using System;
using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator;
using System.IO;
using System.Text.Json;
using RestEase;
using RestEaseClientGeneratorConsoleApp.PetStore.Api;
using System.Threading.Tasks;

namespace RestEaseClientGeneratorConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var generator = new Generator();

            foreach (var file in generator.FromStream(File.OpenRead("petstore.yaml"), "RestEaseClientGeneratorConsoleApp.PetStore", "PetStore", out OpenApiDiagnostic diagnosticPetStore1))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/PetStore/{file.Path}/{file.Name}", file.Content);
            }

            foreach (var file in generator.FromStream(File.OpenRead("petstore.json"), "RestEaseClientGeneratorConsoleApp.PetStoreJson", "PetStoreJson", out OpenApiDiagnostic diagnosticPetStore1))
            {
                File.WriteAllText($"../../../../RestEaseClientGeneratorConsoleApp/PetStoreJson/{file.Path}/{file.Name}", file.Content);
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