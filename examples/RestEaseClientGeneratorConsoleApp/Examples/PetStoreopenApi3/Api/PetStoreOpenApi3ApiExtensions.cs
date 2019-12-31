using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi3.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi3.Api
{
    public static class PetStoreOpenApi3ApiExtensions
    {
        /// <summary>
        /// Updates a pet in the store with form data
        /// </summary>
        /// <param name="api">The Api</param>
        /// <param name="petId">ID of pet that needs to be updated</param>
        /// <param name="name">Updated name of the pet</param>
        /// <param name="status">Updated status of the pet</param>
        public static Task UpdatePetWithFormAsync(this IPetStoreOpenApi3Api api, long petId, string name, string status)
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
        public static Task<ApiResponse> UploadFileAsync(this IPetStoreOpenApi3Api api, long petId, string additionalMetadata, object file)
        {
            var content = new MultipartFormDataContent();

            var formUrlEncodedContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("additionalMetadata", additionalMetadata.ToString()),
                new KeyValuePair<string, string>("file", file.ToString())
            });

            content.Add(formUrlEncodedContent);
            return api.UploadFileAsync(petId, content);
        }
    }
}
