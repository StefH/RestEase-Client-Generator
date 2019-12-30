using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.PetStore.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStore.Api
{
    public interface IPetStoreApi
    {
        /// <summary>
        /// Add a new pet to the store
        /// </summary>
        /// <param name="pet">A pet for sale in the pet store</param>
        [Post("/pet")]
        Task AddPetAsync([Body] Pet pet);

        /// <summary>
        /// Update an existing pet
        /// </summary>
        /// <param name="pet">A pet for sale in the pet store</param>
        [Put("/pet")]
        Task UpdatePetAsync([Body] Pet pet);

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
        Task UpdatePetWithFormAsync([Path] long petId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> form);

        /// <summary>
        /// Deletes a pet
        /// </summary>
        /// <param name="petId">Pet id to delete</param>
        [Delete("/pet/{petId}")]
        Task DeletePetAsync([Path] long petId);

        /// <summary>
        /// uploads an image
        /// </summary>
        /// <param name="petId">ID of pet to update</param>
        /// <param name="content">An extension method is generated to support the exact parameters.</param>
        [Post("/pet/{petId}/uploadImage")]
        Task<ApiResponse> UploadFileAsync([Path] long petId, HttpContent content);

        /// <summary>
        /// Returns pet inventories by status
        /// </summary>
        [Get("/store/inventory")]
        Task<int> GetInventoryAsync();

        /// <summary>
        /// Place an order for a pet
        /// </summary>
        /// <param name="order">An order for a pets from the pet store</param>
        [Post("/store/order")]
        Task<Order> PlaceOrderAsync([Body] Order order);

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
        Task DeleteOrderAsync([Path] string orderId);

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="user">A User who is purchasing from the pet store</param>
        [Post("/user")]
        Task CreateUserAsync([Body] User user);

        /// <summary>
        /// Creates list of users with given input array
        /// </summary>
        /// <param name="iCollectionUser"></param>
        [Post("/user/createWithArray")]
        Task CreateUsersWithArrayInputAsync([Body] ICollection<User> iCollectionUser);

        /// <summary>
        /// Creates list of users with given input array
        /// </summary>
        /// <param name="iCollectionUser"></param>
        [Post("/user/createWithList")]
        Task CreateUsersWithListInputAsync([Body] ICollection<User> iCollectionUser);

        /// <summary>
        /// Logs user into the system
        /// </summary>
        /// <param name="username">The user name for login</param>
        /// <param name="password">The password for login in clear text</param>
        [Get("/user/login")]
        Task LoginUserAsync([Query] string username, [Query] string password);

        /// <summary>
        /// Logs out current logged in user session
        /// </summary>
        [Get("/user/logout")]
        Task LogoutUserAsync();

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
        /// <param name="user">A User who is purchasing from the pet store</param>
        [Put("/user/{username}")]
        Task UpdateUserAsync([Path] string username, [Body] User user);

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="username">The name that needs to be deleted</param>
        [Delete("/user/{username}")]
        Task DeleteUserAsync([Path] string username);
    }
}
