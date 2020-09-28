using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;

namespace AzureRestStorage.Api
{
    /// <summary>
    /// The Azure Storage Management API.
    /// </summary>
    public interface IAzureTableApiApi
    {
        [Query("Azure Active Directory OAuth2 Flow")]
        string AzureActiveDirectoryOAuth2Flow { get; set; }

        /// <summary>
        /// TableServicesList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices)
        /// </summary>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices")]
        Task TableServicesListAsync();

        /// <summary>
        /// TableServicesSetServiceProperties (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/{tableServiceName})
        /// </summary>
        /// <param name="tableServiceName">The name of the Table Service within the specified storage account. Table Service Name must be 'default'</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/{tableServiceName}")]
        [Header("Content-Type", "application/json")]
        Task TableServicesSetServicePropertiesAsync([Path] string tableServiceName);

        /// <summary>
        /// TableServicesGetServiceProperties (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/{tableServiceName})
        /// </summary>
        /// <param name="tableServiceName">The name of the Table Service within the specified storage account. Table Service Name must be 'default'</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/{tableServiceName}")]
        Task TableServicesGetServicePropertiesAsync([Path] string tableServiceName);

        /// <summary>
        /// TableCreate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName})
        /// </summary>
        /// <param name="tableName">A table name must be unique within a storage account and must be between 3 and 63 characters.The name must comprise of only alphanumeric characters and it cannot begin with a numeric character.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName}")]
        Task TableCreateAsync([Path] string tableName);

        /// <summary>
        /// TableUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName})
        /// </summary>
        /// <param name="tableName">A table name must be unique within a storage account and must be between 3 and 63 characters.The name must comprise of only alphanumeric characters and it cannot begin with a numeric character.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName}")]
        Task TableUpdateAsync([Path] string tableName);

        /// <summary>
        /// TableGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName})
        /// </summary>
        /// <param name="tableName">A table name must be unique within a storage account and must be between 3 and 63 characters.The name must comprise of only alphanumeric characters and it cannot begin with a numeric character.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName}")]
        Task TableGetAsync([Path] string tableName);

        /// <summary>
        /// TableDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName})
        /// </summary>
        /// <param name="tableName">A table name must be unique within a storage account and must be between 3 and 63 characters.The name must comprise of only alphanumeric characters and it cannot begin with a numeric character.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName}")]
        Task TableDeleteAsync([Path] string tableName);

        /// <summary>
        /// TableList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables)
        /// </summary>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables")]
        Task TableListAsync();
    }
}
