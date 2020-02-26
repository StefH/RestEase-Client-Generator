using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.SharedQuery.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.SharedQuery.Api
{
    public static class SharedQueryApiExtensions
    {
        /// <summary>
        /// uploads an image
        /// </summary>
        /// <param name="api">The Api</param>
        /// <param name="petId">ID of pet to update</param>
        /// <param name="file">The content.</param>
        public static Task<ApiResponse> UploadFileAsync(this ISharedQueryApi api, long petId, byte[] file)
        {
            var content = new MultipartFormDataContent();

            var fileContent = new ByteArrayContent(file);
            content.Add(fileContent);

            return api.UploadFileAsync(petId, content);
        }
    }
}
