using System;
using System.Threading.Tasks;
using AnyOfTypes.Newtonsoft.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi302.Api;
using RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi302.Models;

namespace RestEaseClientGeneratorConsoleApp
{
    public static class PetStoreOpenApi3ApiTests
    {
        public static async Task RunAsync()
        {
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("PetStoreOpenApi3ApiTests");
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            settings.Converters.Add(new AnyOfJsonConverter());


            //string urlLocal = "http://localhost:8080/api/v3";
            string urlAzure = "https://petstore3-7ea5e6b7-1956-45e8-b452-21d94116e2c4.azurewebsites.net/api/v3";
            //string urlPostman = "https://postman-echo.com/get";
            var petStoreApi = new RestClient(urlAzure)
            {
                JsonSerializerSettings = settings
            }.For<IPetStoreOpenApi3Api>();

            var findPetsByStatusAsync = await petStoreApi.FindPetsByStatusAsync("available");
            if (findPetsByStatusAsync.IsFirst)
            {
                foreach (var find in findPetsByStatusAsync.First)
                {
                    Console.WriteLine("FindPetsByStatusAsync Pets:" + JsonConvert.SerializeObject(find));
                }
            }
            else
            {
                Console.WriteLine("FindPetsByStatusAsync object:" + JsonConvert.SerializeObject(findPetsByStatusAsync.Second.StringContent));
            }

            try
            {
                await petStoreApi.DeletePetAsync(1000);
            }
            catch
            {
                // no-op
            }

            var addPet = await petStoreApi.AddPetAsync(new Pet
            {
                Id = 1000,
                Name = "Rossa",
                Category = new Category { Id = 1, Name = "cat" },
                Tags = new[] { new Tag { Id = 1, Name = "cat" } },
                Status = "available",
                PhotoUrls = new string[] { }
            });
            Console.WriteLine("AddPetAsync:" + JsonConvert.SerializeObject(addPet.CurrentValue));
        }
    }
}