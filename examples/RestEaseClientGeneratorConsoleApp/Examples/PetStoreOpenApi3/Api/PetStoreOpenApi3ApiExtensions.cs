using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi3.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi3.Api
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
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            var fileContent = new ByteArrayContent(file);
            //fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            //content.Add(fileContent);

            return api.UploadFileAsync(petId, fileContent, additionalMetadata);
        }
    }
}
