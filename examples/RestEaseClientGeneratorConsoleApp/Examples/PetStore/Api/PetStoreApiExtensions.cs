using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.PetStore.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStore.Api
{
    public static class PetStoreApiExtensions
    {
        /// <summary>
        /// Updates a pet in the store with form data
        /// </summary>
        /// <param name="api">The Api</param>
        /// <param name="petId">ID of pet that needs to be updated</param>
        /// <param name="name">Updated name of the pet</param>
        /// <param name="status">Updated status of the pet</param>
        public static Task<object> UpdatePetWithFormAsync(this IPetStoreApi api, long petId, string name, string status)
        {
            var form = new Dictionary<string, object>
            {
                { "name", name },
                { "status", status }
            };

            return api.UpdatePetWithFormAsync(petId, form);
        }

        /// <summary>
        /// uploads an image
        /// </summary>
        /// <param name="api">The Api</param>
        /// <param name="petId">ID of pet to update</param>
        /// <param name="additionalMetadata">Additional data to pass to server</param>
        /// <param name="file">file to upload</param>
        public static Task<ApiResponse> UploadFileAsync(this IPetStoreApi api, long petId, string additionalMetadata, byte[] file)
        {
            var content = new MultipartFormDataContent();

            var fileContent = new ByteArrayContent(file);
            content.Add(fileContent);

            var formUrlEncodedContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("additionalMetadata", additionalMetadata.ToString())
            });

            content.Add(formUrlEncodedContent);
            return api.UploadFileAsync(petId, content);
        }
    }
}
