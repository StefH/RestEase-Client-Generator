using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnyOfTypes;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.PetStoreJson.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreJson.Test123
{
    /// <summary>
    /// Summary: This is a sample server Petstore server.  You can find out more about Swagger at [http://swagger.io](http://swagger.io) or on [irc.freenode.net, #swagger](http://swagger.io/irc/).  For this sample, you can use the api key `special-key` to test the authorization filters.
    /// Title  : Swagger Petstore
    /// Version: 1.0.3
    /// </summary>
    public interface IPetStoreJsonApi
    {
        [Header("api_key")]
        string ApiKey { get; set; }

        /// <summary>
        /// Find pet by ID
        ///
        /// GetPetById (/pet/{petId})
        /// </summary>
        /// <param name="petId">ID of pet to return</param>
        [Get("/pet/{petId}")]
        Task<Response<AnyOf<Pet, object>>> GetPetByIdAsync([Path] long petId);

        /// <summary>
        /// Updates a pet in the store with form data
        ///
        /// UpdatePetWithForm (/pet/{petId})
        /// </summary>
        /// <param name="petId">ID of pet that needs to be updated</param>
        /// <param name="form">An extension method is generated to support the exact parameters.</param>
        [Post("/pet/{petId}")]
        [Header("Content-Type", "application/x-www-form-urlencoded")]
        Task<object> UpdatePetWithFormAsync([Path] long petId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> form);

        /// <summary>
        /// Deletes a pet
        ///
        /// DeletePet (/pet/{petId})
        /// </summary>
        /// <param name="petId">Pet id to delete</param>
        /// <param name="apiKey"></param>
        [Delete("/pet/{petId}")]
        Task<object> DeletePetAsync([Path] long petId, [Header("api_key")] string apiKey);

        /// <summary>
        /// uploads an image
        ///
        /// UploadFile (/pet/{petId}/uploadImage)
        /// </summary>
        /// <param name="petId">ID of pet to update</param>
        /// <param name="content">An extension method is generated to support the exact parameters.</param>
        [Post("/pet/{petId}/uploadImage")]
        [Header("Content-Type", "multipart/form-data")]
        Task<ApiResponse> UploadFileAsync([Path] long petId, [Body] HttpContent content);

        /// <summary>
        /// Add a new pet to the store
        ///
        /// AddPet (/pet)
        /// </summary>
        /// <param name="content">Pet object that needs to be added to the store</param>
        [Post("/pet")]
        [Header("Content-Type", "application/json")]
        Task<object> AddPetAsync([Body] Pet content);

        /// <summary>
        /// Update an existing pet
        ///
        /// UpdatePet (/pet)
        /// </summary>
        /// <param name="content">Pet object that needs to be added to the store</param>
        [Put("/pet")]
        [Header("Content-Type", "application/json")]
        Task<object> UpdatePetAsync([Body] Pet content);

        /// <summary>
        /// Finds Pets by status
        ///
        /// FindPetsByStatus (/pet/findByStatus)
        /// </summary>
        /// <param name="status">Status values that need to be considered for filter</param>
        [Get("/pet/findByStatus")]
        Task<Response<AnyOf<IEnumerable<Pet>, object>>> FindPetsByStatusAsync([Query] string Status);

        /// <summary>
        /// Finds Pets by tags
        ///
        /// FindPetsByTags (/pet/findByTags)
        /// </summary>
        /// <param name="tags">Tags to filter by</param>
        [Get("/pet/findByTags")]
        Task<Response<AnyOf<IEnumerable<Pet>, object>>> FindPetsByTagsAsync([Query] string Tags);

        /// <summary>
        /// Returns pet inventories by status
        ///
        /// GetInventory (/store/inventory)
        /// </summary>
        [Get("/store/inventory")]
        Task<int> GetInventoryAsync();

        /// <summary>
        /// Find purchase order by ID
        ///
        /// GetOrderById (/store/order/{orderId})
        /// </summary>
        /// <param name="orderId">ID of pet that needs to be fetched</param>
        [Get("/store/order/{orderId}")]
        Task<Response<AnyOf<Order, object>>> GetOrderByIdAsync([Path] long orderId);

        /// <summary>
        /// Delete purchase order by ID
        ///
        /// DeleteOrder (/store/order/{orderId})
        /// </summary>
        /// <param name="orderId">ID of the order that needs to be deleted</param>
        [Delete("/store/order/{orderId}")]
        Task<object> DeleteOrderAsync([Path] long orderId);

        /// <summary>
        /// Place an order for a pet
        ///
        /// PlaceOrder (/store/order)
        /// </summary>
        /// <param name="content">order placed for purchasing the pet</param>
        [Post("/store/order")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Order, object>>> PlaceOrderAsync([Body] Order content);

        /// <summary>
        /// Get user by user name
        ///
        /// GetUserByName (/user/{username})
        /// </summary>
        /// <param name="username">The name that needs to be fetched. Use user1 for testing. </param>
        [Get("/user/{username}")]
        Task<Response<AnyOf<User, object>>> GetUserByNameAsync([Path] string username);

        /// <summary>
        /// Updated user
        ///
        /// UpdateUser (/user/{username})
        /// </summary>
        /// <param name="username">name that need to be updated</param>
        /// <param name="content">Updated user object</param>
        [Put("/user/{username}")]
        [Header("Content-Type", "application/json")]
        Task<object> UpdateUserAsync([Path] string username, [Body] User content);

        /// <summary>
        /// Delete user
        ///
        /// DeleteUser (/user/{username})
        /// </summary>
        /// <param name="username">The name that needs to be deleted</param>
        [Delete("/user/{username}")]
        Task<object> DeleteUserAsync([Path] string username);

        /// <summary>
        /// Logs user into the system
        ///
        /// LoginUser (/user/login)
        /// </summary>
        /// <param name="username">The user name for login</param>
        /// <param name="password">The password for login in clear text</param>
        [Get("/user/login")]
        Task<Response<AnyOf<string, object>>> LoginUserAsync([Query] string username, [Query] string password);

        /// <summary>
        /// Logs out current logged in user session
        ///
        /// LogoutUser (/user/logout)
        /// </summary>
        [Get("/user/logout")]
        Task<object> LogoutUserAsync();

        /// <summary>
        /// Create user
        ///
        /// CreateUser (/user)
        /// </summary>
        /// <param name="content">Created user object</param>
        [Post("/user")]
        [Header("Content-Type", "application/json")]
        Task<object> CreateUserAsync([Body] User content);

        /// <summary>
        /// Creates list of users with given input array
        ///
        /// CreateUsersWithArrayInput (/user/createWithArray)
        /// </summary>
        /// <param name="content">List of user object</param>
        [Post("/user/createWithArray")]
        [Header("Content-Type", "application/json")]
        Task<object> CreateUsersWithArrayInputAsync([Body] IEnumerable<User> content);

        /// <summary>
        /// Creates list of users with given input array
        ///
        /// CreateUsersWithListInput (/user/createWithList)
        /// </summary>
        /// <param name="content">List of user object</param>
        [Post("/user/createWithList")]
        [Header("Content-Type", "application/json")]
        Task<object> CreateUsersWithListInputAsync([Body] IEnumerable<User> content);
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreJson.Test123
{
    public static class PetStoreJsonApiExtensions
    {
        /// <summary>
        /// Updates a pet in the store with form data
        /// </summary>
        /// <param name="api">The Api</param>
        /// <param name="petId">ID of pet that needs to be updated</param>
        /// <param name="name">Updated name of the pet</param>
        /// <param name="status">Updated status of the pet</param>
        public static Task<object> UpdatePetWithFormAsync(this IPetStoreJsonApi api, long petId, string name, string status)
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
        public static Task<ApiResponse> UploadFileAsync(this IPetStoreJsonApi api, long petId, string additionalMetadata, System.IO.Stream file)
        {
            var content = new MultipartFormDataContent();

            var fileContent = new StreamContent(file);
            content.Add(fileContent);

            var formUrlEncodedContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("additionalMetadata", additionalMetadata.ToString())
            });

            content.Add(formUrlEncodedContent);
            return api.UploadFileAsync(petId, content);
        }
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreJson.Models
{
    public class ApiResponse
    {
        public int Code { get; set; }

        public string Type { get; set; }

        public string Message { get; set; }
    }

    public class Category
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }

    public class Order
    {
        public long Id { get; set; }

        public long PetId { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset ShipDate { get; set; }

        /// <summary>
        /// Order Status
        /// </summary>
        public string Status { get; set; }

        public bool Complete { get; set; }
    }

    public class Pet
    {
        public long Id { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> PhotoUrls { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        /// <summary>
        /// pet status in the store
        /// </summary>
        public string Status { get; set; }
    }

    public class Tag
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }

    public class User
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// User Status
        /// </summary>
        public int UserStatus { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreJson.Models
{
    public static class StatusConstants
    {
        public const string Available = "available";

        public const string Pending = "pending";

        public const string Sold = "sold";
    }

    /// <summary>
    /// Order Status
    /// </summary>
    public static class OrderStatusConstants
    {
        public const string Placed = "placed";

        public const string Approved = "approved";

        public const string Delivered = "delivered";
    }

    /// <summary>
    /// pet status in the store
    /// </summary>
    public static class PetStatusConstants
    {
        public const string Available = "available";

        public const string Pending = "pending";

        public const string Sold = "sold";
    }
}
