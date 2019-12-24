using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.PetStoreJson.Models;

namespace RestEaseClientGeneratorConsoleApp.PetStoreJson.Api
{
    public interface IPetStoreJsonApi
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

        /// <summary>
        /// Find pet by ID
        /// </summary>
        /// <param name="petId">ID of pet to return</param>
        [Get("/pet/{petId}")]
        Task<Response<Pet>> GetPetByIdAsync([Path] long petId);

        /// <summary>
        /// Updates a pet in the store with form data
        /// </summary>
        /// <param name="petId">ID of pet that needs to be updated</param>
        [Post("/pet/{petId}")]
        Task UpdatePetWithFormAsync([Path] long petId);

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
        [Post("/pet/{petId}/uploadImage")]
        Task<Response<ApiResponse>> UploadFileAsync([Path] long petId);

        /// <summary>
        /// Add a new pet to the store
        /// </summary>
        /// <param name="pet"></param>
        [Post("/pet")]
        Task AddPetAsync([Body] Pet pet);

        /// <summary>
        /// Update an existing pet
        /// </summary>
        /// <param name="pet"></param>
        [Put("/pet")]
        Task UpdatePetAsync([Body] Pet pet);

        /// <summary>
        /// Finds Pets by status
        /// </summary>
        /// <param name="status">Status values that need to be considered for filter</param>
        [Get("/pet/findByStatus")]
        Task<Response<IEnumerable<Pet>>> FindPetsByStatusAsync([Query] IEnumerable<string> status);

        /// <summary>
        /// Finds Pets by tags
        /// </summary>
        /// <param name="tags">Tags to filter by</param>
        [Get("/pet/findByTags")]
        Task<Response<IEnumerable<Pet>>> FindPetsByTagsAsync([Query] IEnumerable<string> tags);

        /// <summary>
        /// Returns pet inventories by status
        /// </summary>
        [Get("/store/inventory")]
        Task<Response<int>> GetInventoryAsync();

        /// <summary>
        /// Find purchase order by ID
        /// </summary>
        /// <param name="orderId">ID of pet that needs to be fetched</param>
        [Get("/store/order/{orderId}")]
        Task<Response<Order>> GetOrderByIdAsync([Path] long orderId);

        /// <summary>
        /// Delete purchase order by ID
        /// </summary>
        /// <param name="orderId">ID of the order that needs to be deleted</param>
        [Delete("/store/order/{orderId}")]
        Task DeleteOrderAsync([Path] long orderId);

        /// <summary>
        /// Place an order for a pet
        /// </summary>
        /// <param name="order"></param>
        [Post("/store/order")]
        Task<Response<Order>> PlaceOrderAsync([Body] Order order);

        /// <summary>
        /// Get user by user name
        /// </summary>
        /// <param name="username">The name that needs to be fetched. Use user1 for testing. </param>
        [Get("/user/{username}")]
        Task<Response<User>> GetUserByNameAsync([Path] string username);

        /// <summary>
        /// Updated user
        /// </summary>
        /// <param name="username">name that need to be updated</param>
        /// <param name="user"></param>
        [Put("/user/{username}")]
        Task UpdateUserAsync([Path] string username, [Body] User user);

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="username">The name that needs to be deleted</param>
        [Delete("/user/{username}")]
        Task DeleteUserAsync([Path] string username);

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
        /// Create user
        /// </summary>
        /// <param name="user"></param>
        [Post("/user")]
        Task CreateUserAsync([Body] User user);

        /// <summary>
        /// Creates list of users with given input array
        /// </summary>
        /// <param name="iEnumerableUser"></param>
        [Post("/user/createWithArray")]
        Task CreateUsersWithArrayInputAsync([Body] IEnumerable<User> iEnumerableUser);

        /// <summary>
        /// Creates list of users with given input array
        /// </summary>
        /// <param name="iEnumerableUser"></param>
        [Post("/user/createWithList")]
        Task CreateUsersWithListInputAsync([Body] IEnumerable<User> iEnumerableUser);
    }
}

namespace RestEaseClientGeneratorConsoleApp.PetStoreJson.Models
{
    public class Category
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}

namespace RestEaseClientGeneratorConsoleApp.PetStoreJson.Models
{
    public class Pet
    {
        public long Id { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> PhotoUrls { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public string Status { get; set; }
    }
}

namespace RestEaseClientGeneratorConsoleApp.PetStoreJson.Models
{
    public class Tag
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}

namespace RestEaseClientGeneratorConsoleApp.PetStoreJson.Models
{
    public class ApiResponse
    {
        public int Code { get; set; }

        public string Type { get; set; }

        public string Message { get; set; }
    }
}

namespace RestEaseClientGeneratorConsoleApp.PetStoreJson.Models
{
    public class Order
    {
        public long Id { get; set; }

        public long PetId { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset ShipDate { get; set; }

        public string Status { get; set; }

        public bool Complete { get; set; }
    }
}

namespace RestEaseClientGeneratorConsoleApp.PetStoreJson.Models
{
    public class User
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public int UserStatus { get; set; }
    }
}

