using System;
using System.Text;
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

            //var findPetsByStatusAsync3 = await petStoreApi.FindPetsByStatusAsync3("available");
            //var r = findPetsByStatusAsync3.GetContent();
            //if (r.IsFirst)
            //{
            //    foreach (var find in r.First)
            //    {
            //        Console.WriteLine("FindPetsByStatusAsync Pets:" + JsonConvert.SerializeObject(find));
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("FindPetsByStatusAsync object:" + JsonConvert.SerializeObject(r.Second));
            //}

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

            //var findPetsByStatusAsync = await petStoreApi.FindPetsByStatusAsync(Status2.available);
            //foreach (var find in findPetsByStatusAsync)
            //{
            //    Console.WriteLine("FindPetsByStatusAsync:" + JsonConvert.SerializeObject(find));
            //}

            // await petStoreApi.DeletePetAsync(1000);

            //var addPet = await petStoreApi.AddPetAsync(new Pet
            //{
            //    Id = 1000,
            //    Name = "Rossa",
            //    Category = new Category { Id = 1, Name = "cat" },
            //    Tags = new[] { new Tag { Id = 1, Name = "cat" } },
            //    Status = Status2.available,
            //    PhotoUrls = new string[] { }
            //});
            //Console.WriteLine("AddPetAsync:" + JsonSerializer.Serialize(addPet));

            //var getPetById = await petStoreApi.GetPetByPetIdAsync(1000);
            //Console.WriteLine("GetPetByIdAsync:" + JsonConvert.SerializeObject(getPetById));

            //var uploadFileResponse = await petStoreApi.UploadFileAsync(1000, "rossa", Encoding.UTF8.GetBytes("Poes"));
            //Console.WriteLine("UploadFileAsync:" + JsonConvert.SerializeObject(uploadFileResponse));

            //var stream = File.OpenRead("Examples\\petstore-openapi3.json");
            //var uploadFile = await petStoreApi.UploadFileAsync(1000, "rossa", stream);
            //Console.WriteLine("UploadFileAsync:" + uploadFile.ToString());
        }
    }
}