using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi3.Api;
using RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi3.Models;
using System;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace RestEaseClientGeneratorConsoleApp
{
    public static class PetStoreOpenApi3ApiTests
    {
        public static async Task Run()
        {
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("PetStoreOpenApi3ApiTests");
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var petStoreApi = new RestClient("https://petstore3-7ea5e6b7-1956-45e8-b452-21d94116e2c4.azurewebsites.net/api/v3")
            {
                JsonSerializerSettings = settings
            }.For<IPetStoreOpenApi3Api>();

            var findPetsByTags = await petStoreApi.FindPetsByTagsAsync(new[] { "cat" });
            foreach (var find in findPetsByTags)
            {
                Console.WriteLine("FindPetsByTagsAsync:" + JsonSerializer.Serialize(find));
            }

            var addPet = await petStoreApi.AddPetAsync(new Pet
            {
                Id = 1000,
                Name = "Rossa",
                Category = new Category { Id = 1, Name = "cat" },
                Tags = new[] { new Tag { Id = 1, Name = "cat" } },
                Status = "Sleepy"
            });
            Console.WriteLine("AddPetAsync:" + JsonSerializer.Serialize(addPet));

            var getPetById = await petStoreApi.GetPetByIdAsync(1000);
            Console.WriteLine("GetPetByIdAsync:" + JsonSerializer.Serialize(getPetById));
        }
    }
}