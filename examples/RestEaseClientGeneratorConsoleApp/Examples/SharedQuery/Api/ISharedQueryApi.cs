using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.SharedQuery.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.SharedQuery.Api
{
    /// <summary>
    /// This is a sample Pet Store Server based on the OpenAPI 3.0 specification.  You can find out more aboutSwagger at [http://swagger.io](http://swagger.io). In the third iteration of the pet store, we've switched to the design first approach!You can now help us improve the API whether it's by making changes to the definition itself or to the code.That way, with time, we can improve the API in general, and expose some of the new features in OAS3.Some useful links:- [The Pet Store repository](https://github.com/swagger-api/swagger-petstore)- [The source API definition for the Pet Store](https://github.com/swagger-api/swagger-petstore/blob/master/src/main/resources/openapi.yaml) 
    /// </summary>
    public interface ISharedQueryApi
    {
        [Query("api-version")]
        string ApiVersion { get; set; }

        /// <summary>
        /// Update an existing pet
        /// </summary>
        /// <param name="content">Update an existent pet in the store</param>
        [Put("/pet")]
        [Header("Content-Type", "application/json")]
        Task<Pet> UpdatePetAsync([Body] Pet content);

        /// <summary>
        /// uploads an image
        /// </summary>
        /// <param name="petId">ID of pet to update</param>
        /// <param name="content">An extension method is generated to support the exact parameters.</param>
        [Post("/pet/{petId}/uploadImage")]
        [Header("Content-Type", "application/octet-stream")]
        Task<ApiResponse> UploadFileAsync([Path] long petId, [Body] HttpContent content);
    }
}
