using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.PetStore.Api;
using RestEaseClientGeneratorConsoleApp.Examples.PetStore.Models;
using System;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace RestEaseClientGeneratorConsoleApp
{
    public static class PetStoreTests
    {
        public static async Task Run()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var petStoreApi = new RestClient("https://petstore.swagger.io/v2")
            {
                JsonSerializerSettings = settings
            }.For<IPetStoreApi>();

            var findPetsByTags = await petStoreApi.FindPetsByTagsAsync(new[] { "cat" });
            foreach (var find in findPetsByTags)
            {
                Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(find));
            }

            var addPet = await petStoreApi.AddPetAsync(new Pet
            {
                Id = 1000,
                Name = "Rossa",
                Status = "Sleepy"
            });
            Console.WriteLine(addPet.ToString());

            var getPetById = await petStoreApi.GetPetByIdAsync(1000);
            Console.WriteLine(JsonSerializer.Serialize(getPetById));
        }
    }
}