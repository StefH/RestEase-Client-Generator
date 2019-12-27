using RestEase;
using RestEaseClientGeneratorConsoleApp.PetStoreJson.Api;
using RestEaseClientGeneratorConsoleApp.PetStoreJson.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestEaseClientGeneratorConsoleApp.PetStoreJson
{
    public static class PetStoreJsonApiExtensions
    {
        public static Task<ApiResponse> UploadAsync(this IPetStoreJsonApi api, long petId, string additionalMetadata, byte[] file)
        {
            var multipartFormDataContent = new MultipartFormDataContent();

            var imageContent = new ByteArrayContent(file);
            multipartFormDataContent.Add(imageContent);

            var tokenContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("additionalMetadata", additionalMetadata)
            });
            multipartFormDataContent.Add(tokenContent);

            return api.UploadFileAsync(petId, multipartFormDataContent);
        }
    }
}