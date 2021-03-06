using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.PetStoreJson.Modelz;

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreJson.Test123
{
    /// <summary>
    /// This is a sample server Petstore server.  You can find out more about Swagger at [http://swagger.io](http://swagger.io) or on [irc.freenode.net, #swagger](http://swagger.io/irc/).  For this sample, you can use the api key `special-key` to test the authorization filters.
    /// </summary>
    public interface IPetStoreJsonApi
    {
        [Header("api_key")]
        string ApiKey { get; set; }

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
        Task UpdatePetWithFormAsync([Path] long petId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> form);

        /// <summary>
        /// Deletes a pet
        /// </summary>
        /// <param name="petId">Pet id to delete</param>
        /// <param name="apiKey"></param>
        [Delete("/pet/{petId}")]
        Task DeletePetAsync([Path] long petId, [Header("api_key")] string apiKey);

        /// <summary>
        /// uploads an image
        /// </summary>
        /// <param name="petId">ID of pet to update</param>
        /// <param name="content">An extension method is generated to support the exact parameters.</param>
        [Post("/pet/{petId}/uploadImage")]
        [Header("Content-Type", "multipart/form-data")]
        Task<ApiResponse> UploadFileAsync([Path] long petId, [Body] HttpContent content);

        /// <summary>
        /// Add a new pet to the store
        /// </summary>
        /// <param name="content">Pet object that needs to be added to the store</param>
        [Post("/pet")]
        [Header("Content-Type", "application/json")]
        Task AddPetAsync([Body] Pet content);

        /// <summary>
        /// Update an existing pet
        /// </summary>
        /// <param name="content">Pet object that needs to be added to the store</param>
        [Put("/pet")]
        [Header("Content-Type", "application/json")]
        Task UpdatePetAsync([Body] Pet content);

        /// <summary>
        /// Finds Pets by status
        /// </summary>
        /// <param name="status">Status values that need to be considered for filter</param>
        [Get("/pet/findByStatus")]
        Task<IEnumerable<Pet>> FindPetsByStatusAsync([Query] IEnumerable<string> status);

        /// <summary>
        /// Finds Pets by tags
        /// </summary>
        /// <param name="tags">Tags to filter by</param>
        [Get("/pet/findByTags")]
        Task<IEnumerable<Pet>> FindPetsByTagsAsync([Query] IEnumerable<string> tags);

        /// <summary>
        /// Returns pet inventories by status
        /// </summary>
        [Get("/store/inventory")]
        Task<int> GetInventoryAsync();

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
        Task DeleteOrderAsync([Path] long orderId);

        /// <summary>
        /// Place an order for a pet
        /// </summary>
        /// <param name="content">order placed for purchasing the pet</param>
        [Post("/store/order")]
        [Header("Content-Type", "application/json")]
        Task<Order> PlaceOrderAsync([Body] Order content);

        /// <summary>
        /// Get user by user name
        /// </summary>
        /// <param name="username">The name that needs to be fetched. Use user1 for testing. </param>
        [Get("/user/{username}")]
        Task<User> GetUserByNameAsync([Path] string username);

        /// <summary>
        /// Updated user
        /// </summary>
        /// <param name="username">name that need to be updated</param>
        /// <param name="content">Updated user object</param>
        [Put("/user/{username}")]
        [Header("Content-Type", "application/json")]
        Task UpdateUserAsync([Path] string username, [Body] User content);

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
        /// <param name="content">Created user object</param>
        [Post("/user")]
        [Header("Content-Type", "application/json")]
        Task CreateUserAsync([Body] User content);

        /// <summary>
        /// Creates list of users with given input array
        /// </summary>
        /// <param name="content">List of user object</param>
        [Post("/user/createWithArray")]
        [Header("Content-Type", "application/json")]
        Task CreateUsersWithArrayInputAsync([Body] IEnumerable<User> content);

        /// <summary>
        /// Creates list of users with given input array
        /// </summary>
        /// <param name="content">List of user object</param>
        [Post("/user/createWithList")]
        [Header("Content-Type", "application/json")]
        Task CreateUsersWithListInputAsync([Body] IEnumerable<User> content);
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
        public static Task UpdatePetWithFormAsync(this IPetStoreJsonApi api, long petId, string name, string status)
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

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreJson.Modelz
{
    public class Category
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreJson.Modelz
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

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreJson.Modelz
{
    public class Tag
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreJson.Modelz
{
    public class ApiResponse
    {
        public int Code { get; set; }

        public string Type { get; set; }

        public string Message { get; set; }
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreJson.Modelz
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

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreJson.Modelz
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
