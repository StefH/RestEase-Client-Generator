using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi302.Api;
using RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi302.Models;
using System;
using System.IO;
using System.Text;
using System.Text.Unicode;
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
            string urlLocal = "http://localhost:8080/api/v3";
            string urlAzure = "https://petstore3-7ea5e6b7-1956-45e8-b452-21d94116e2c4.azurewebsites.net/api/v3";
            // string urlPostman = "https://postman-echo.com/post";
            var petStoreApi = new RestClient(urlAzure)
            {
                JsonSerializerSettings = settings
            }.For<IPetStoreOpenApi3Api>();

            var findPetsByTags = await petStoreApi.FindPetsByTagsAsync(new[] { "cat" });
            foreach (var find in findPetsByTags)
            {
                Console.WriteLine("FindPetsByTagsAsync:" + JsonSerializer.Serialize(find));
            }

            var findPetsByStatusAsync = await petStoreApi.FindPetsByStatusAsync("available");
            foreach (var find in findPetsByStatusAsync)
            {
                Console.WriteLine("FindPetsByStatusAsync:" + JsonSerializer.Serialize(find));
            }

            await petStoreApi.DeletePetAsync(1000);

            var addPet = await petStoreApi.AddPetAsync(new Pet
            {
                Id = 1000,
                Name = "Rossa",
                Category = new Category { Id = 1, Name = "cat" },
                Tags = new[] { new Tag { Id = 1, Name = "cat" } },
                Status = "available",
                PhotoUrls = new string[] { }
            });
            Console.WriteLine("AddPetAsync:" + JsonSerializer.Serialize(addPet));

            var getPetById = await petStoreApi.GetPetByPetIdAsync(1000);
            Console.WriteLine("GetPetByIdAsync:" + JsonSerializer.Serialize(getPetById));

            //var uploadFile = await petStoreApi.UploadFileAsync(1000, "rossa", Encoding.UTF8.GetBytes("Poes"));
            //Console.WriteLine("UploadFileAsync:" + uploadFile.ToString());

            //var stream = File.OpenRead("Examples\\petstore-openapi3.json");
            //var uploadFile = await petStoreApi.UploadFileAsync(1000, "rossa", stream);
            //Console.WriteLine("UploadFileAsync:" + uploadFile.ToString());
        }
    }
}