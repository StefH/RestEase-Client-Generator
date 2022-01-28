using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnyOfTypes;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi302.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi302.Api
{
    /// <summary>
    /// This is a sample Pet Store Server based on the OpenAPI 3.0 specification.  You can find out more aboutSwagger at [http://swagger.io](http://swagger.io). In the third iteration of the pet store, we've switched to the design first approach!You can now help us improve the API whether it's by making changes to the definition itself or to the code.That way, with time, we can improve the API in general, and expose some of the new features in OAS3.Some useful links:- [The Pet Store repository](https://github.com/swagger-api/swagger-petstore)- [The source API definition for the Pet Store](https://github.com/swagger-api/swagger-petstore/blob/master/src/main/resources/openapi.yaml) 
    /// </summary>
    public interface IPetStoreOpenApi3Api
    {
        [Header("api_key", "0x0001")]
        string ApiKey { get; set; }

        /// <summary>
        /// Update an existing pet
        /// </summary>
        /// <param name="content">Update an existent pet in the store</param>
        [Put("/pet")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Pet, object>>> UpdatePetAsync([Body] Pet content);

        /// <summary>
        /// Add a new pet to the store
        /// </summary>
        /// <param name="content">Create a new pet in the store</param>
        [Post("/pet")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Pet, object>>> AddPetAsync([Body] Pet content);

        /// <summary>
        /// Finds Pets by status
        /// </summary>
        /// <param name="status">Status values that need to be considered for filter</param>
        [Get("/pet/findByStatus")]
        Task<Response<AnyOf<Pet[], object>>> FindPetsByStatusAsync([Query] string status);

        /// <summary>
        /// Finds Pets by tags
        /// </summary>
        /// <param name="tags">Tags to filter by</param>
        [Get("/pet/findByTags")]
        Task<Response<AnyOf<Pet[], object>>> FindPetsByTagsAsync([Query] string[] tags);

        /// <summary>
        /// Find pet by ID
        /// </summary>
        /// <param name="petId">ID of pet to return</param>
        [Get("/pet/{petId}")]
        Task<Response<AnyOf<Pet, object>>> GetPetByPetIdAsync([Path] long petId);

        /// <summary>
        /// Updates a pet in the store with form data
        /// </summary>
        /// <param name="petId">ID of pet that needs to be updated</param>
        /// <param name="name">Name of pet that needs to be updated</param>
        /// <param name="status">Status of pet that needs to be updated</param>
        [Post("/pet/{petId}")]
        Task<object> UpdatePetWithFormAsync([Path] long petId, [Query] string name, [Query] string status);

        /// <summary>
        /// Deletes a pet
        /// </summary>
        /// <param name="petId">Pet id to delete</param>
        /// <param name="apiKey"></param>
        [Delete("/pet/{petId}")]
        Task<object> DeletePetAsync([Path] long petId);

        /// <summary>
        /// uploads an image
        /// </summary>
        /// <param name="petId">ID of pet to update</param>
        /// <param name="content">An extension method is generated to support the exact parameters.</param>
        /// <param name="additionalMetadata">Additional Metadata</param>
        [Post("/pet/{petId}/uploadImage")]
        [Header("Content-Type", "application/octet-stream")]
        Task<ApiResponse> UploadFileAsync([Path] long petId, [Body] HttpContent content, [Query] string additionalMetadata);

        /// <summary>
        /// Returns pet inventories by status
        /// </summary>
        [Get("/store/inventory")]
        Task<int> GetInventoryAsync();

        /// <summary>
        /// Place an order for a pet
        /// </summary>
        /// <param name="content"></param>
        [Post("/store/order")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Order, object>>> PlaceOrderAsync([Body] Order content);

        /// <summary>
        /// Find purchase order by ID
        /// </summary>
        /// <param name="orderId">ID of order that needs to be fetched</param>
        [Get("/store/order/{orderId}")]
        Task<Response<AnyOf<Order, object>>> GetOrderByIdAsync([Path] long orderId);

        /// <summary>
        /// Delete purchase order by ID
        /// </summary>
        /// <param name="orderId">ID of the order that needs to be deleted</param>
        [Delete("/store/order/{orderId}")]
        Task<object> DeleteOrderAsync([Path] long orderId);

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="content">Created user object</param>
        [Post("/user")]
        [Header("Content-Type", "application/json")]
        Task<User> CreateUserAsync([Body] User content);

        /// <summary>
        /// Creates list of users with given input array
        /// </summary>
        /// <param name="content"></param>
        [Post("/user/createWithList")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<User, object>>> CreateUsersWithListInputAsync([Body] User[] content);

        /// <summary>
        /// Logs user into the system
        /// </summary>
        /// <param name="username">The user name for login</param>
        /// <param name="password">The password for login in clear text</param>
        [Get("/user/login")]
        Task<Response<AnyOf<string, object>>> LoginUserAsync([Query] string username, [Query] string password);

        /// <summary>
        /// Logs out current logged in user session
        /// </summary>
        [Get("/user/logout")]
        Task<object> LogoutUserAsync();

        /// <summary>
        /// Get user by user name
        /// </summary>
        /// <param name="username">The name that needs to be fetched. Use user1 for testing. </param>
        [Get("/user/{username}")]
        Task<Response<AnyOf<User, object>>> GetUserByNameAsync([Path] string username);

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="username">name that need to be deleted</param>
        /// <param name="content">Update an existent user in the store</param>
        [Put("/user/{username}")]
        [Header("Content-Type", "application/json")]
        Task<object> UpdateUserAsync([Path] string username, [Body] User content);

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="username">The name that needs to be deleted</param>
        [Delete("/user/{username}")]
        Task<object> DeleteUserAsync([Path] string username);
    }
}