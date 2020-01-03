using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi302.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi302.Api
{
    public static class PetStoreOpenApi3ApiExtensions
    {
        /// <summary>
        /// uploads an image
        /// </summary>
        /// <param name="api">The Api</param>
        /// <param name="petId">ID of pet to update</param>
        /// <param name="additionalMetadata">Additional Metadata</param>
        /// <param name="file">The content.</param>
        public static Task<ApiResponse> UploadFileAsync(this IPetStoreOpenApi3Api api, long petId, string additionalMetadata, byte[] file)
        {
            var content = new MultipartFormDataContent();

            var fileContent = new ByteArrayContent(file);
            content.Add(fileContent);

            return api.UploadFileAsync(petId, content, additionalMetadata);
        }
    }
}
