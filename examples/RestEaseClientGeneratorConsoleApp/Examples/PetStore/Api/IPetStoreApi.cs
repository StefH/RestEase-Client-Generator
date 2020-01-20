using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.PetStore.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStore.Api
{
    /// <summary>
    /// This is a sample server Petstore server. Copied from https://github.com/swagger-api/swagger-codegen/blob/master/modules/swagger-codegen/src/test/resources/2_0/petstore.yaml.
    /// </summary>
    public interface IPetStoreApi
    {
        [Header("api_key")]
        string ApiKey { get; set; }

        /// <summary>
        /// Add a new pet to the store
        /// </summary>
        /// <param name="content">A pet for sale in the pet store</param>
        [Post("/pet")]
        [Header("Content-Type", "application/json")]
        Task<object> AddPetAsync([Body] Pet content);

        /// <summary>
        /// Update an existing pet
        /// </summary>
        /// <param name="content">A pet for sale in the pet store</param>
        [Put("/pet")]
        [Header("Content-Type", "application/json")]
        Task<object> UpdatePetAsync([Body] Pet content);

        /// <summary>
        /// Finds Pets by status
        /// </summary>
        /// <param name="status">Status values that need to be considered for filter</param>
        [Get("/pet/findByStatus")]
        Task<ICollection<Pet>> FindPetsByStatusAsync([Query] ICollection<string> status);

        /// <summary>
        /// Finds Pets by tags
        /// </summary>
        /// <param name="tags">Tags to filter by</param>
        [Get("/pet/findByTags")]
        Task<ICollection<Pet>> FindPetsByTagsAsync([Query] ICollection<string> tags);

        /// <summary>
        /// Find pet by ID
        /// </summary>
        /// <param name="petId">ID of pet to return</param>
        [Get("/pet/{petId}")]
        Task<Pet> GetPetByIdAsync([Path] long petId);

        /// <summary>
        /// Updates a pet in the store with form data
        /// </summary>
        /// <param name="petId">ID of pet that needs to be updated</param>
        /// <param name="form">An extension method is generated to support the exact parameters.</param>
        [Post("/pet/{petId}")]
        [Header("Content-Type", "application/x-www-form-urlencoded")]
        Task<object> UpdatePetWithFormAsync([Path] long petId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> form);

        /// <summary>
        /// Deletes a pet
        /// </summary>
        /// <param name="petId">Pet id to delete</param>
        /// <param name="apiKey"></param>
        [Delete("/pet/{petId}")]
        Task<object> DeletePetAsync([Path] long petId, [Header("api_key")] string apiKey = null);

        /// <summary>
        /// uploads an image
        /// </summary>
        /// <param name="petId">ID of pet to update</param>
        /// <param name="content">An extension method is generated to support the exact parameters.</param>
        [Post("/pet/{petId}/uploadImage")]
        [Header("Content-Type", "multipart/form-data")]
        Task<ApiResponse> UploadFileAsync([Path] long petId, [Body] HttpContent content);

        /// <summary>
        /// Returns pet inventories by status
        /// </summary>
        [Get("/store/inventory")]
        Task<int> GetInventoryAsync();

        /// <summary>
        /// Place an order for a pet
        /// </summary>
        /// <param name="content">An order for a pets from the pet store</param>
        [Post("/store/order")]
        [Header("Content-Type", "application/json")]
        Task<Order> PlaceOrderAsync([Body] Order content);

        /// <summary>
        /// Find purchase order by ID
        /// </summary>
        /// <param name="orderId">ID of pet that needs to be fetched</param>
        [Get("/store/order/{orderId}")]
        Task<Order> GetOrderByIdAsync([Path] long orderId);

        /// <summary>
        /// Delete purchase order by ID
        /// </summary>
        /// <param name="orderId">ID of the order that needs to be deleted</param>
        [Delete("/store/order/{orderId}")]
        Task<object> DeleteOrderAsync([Path] string orderId);

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="content">A User who is purchasing from the pet store</param>
        [Post("/user")]
        [Header("Content-Type", "application/json")]
        Task<object> CreateUserAsync([Body] User content);

        /// <summary>
        /// Creates list of users with given input array
        /// </summary>
        /// <param name="content">List of user object</param>
        [Post("/user/createWithArray")]
        [Header("Content-Type", "application/json")]
        Task<object> CreateUsersWithArrayInputAsync([Body] ICollection<User> content);

        /// <summary>
        /// Creates list of users with given input array
        /// </summary>
        /// <param name="content">List of user object</param>
        [Post("/user/createWithList")]
        [Header("Content-Type", "application/json")]
        Task<object> CreateUsersWithListInputAsync([Body] ICollection<User> content);

        /// <summary>
        /// Logs user into the system
        /// </summary>
        /// <param name="username">The user name for login</param>
        /// <param name="password">The password for login in clear text</param>
        [Get("/user/login")]
        Task<object> LoginUserAsync([Query] string username, [Query] string password);

        /// <summary>
        /// Logs out current logged in user session
        /// </summary>
        [Get("/user/logout")]
        Task<object> LogoutUserAsync();

        /// <summary>
        /// Get user by user name
        /// </summary>
        /// <param name="username">The name that needs to be fetched. Use user1 for testing.</param>
        [Get("/user/{username}")]
        Task<User> GetUserByNameAsync([Path] string username);

        /// <summary>
        /// Updated user
        /// </summary>
        /// <param name="username">name that need to be deleted</param>
        /// <param name="content">A User who is purchasing from the pet store</param>
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
