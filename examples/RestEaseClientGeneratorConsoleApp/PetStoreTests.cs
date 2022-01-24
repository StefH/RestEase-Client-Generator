using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.PetStore.Api;
using RestEaseClientGeneratorConsoleApp.Examples.PetStore.Models;

namespace RestEaseClientGeneratorConsoleApp
{
    public static class PetStoreTests
    {
        public static async Task RunAsync()
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
                Console.WriteLine(JsonConvert.SerializeObject(find));
            }

            try
            {
                await petStoreApi.DeletePetAsync(1000, "");
            }
            catch
            {
                // no-op
            }

            var addPet = await petStoreApi.AddPetAsync(new Pet
            {
                Id = 1000,
                Name = "Rossa",
                Status = "available"
            });
            Console.WriteLine(addPet.ToString());

            var getPetById = await petStoreApi.GetPetByIdAsync(1000);
            Console.WriteLine(JsonConvert.SerializeObject(getPetById));
        }
    }
}