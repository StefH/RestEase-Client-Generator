using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnyOfTypes;
using RestEase;
using MicrosoftExampleConsoleApp.MicrosoftStorage.Models;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Api
{
    /// <summary>
    /// Summary: The Azure Storage Management API.
    /// Title  : StorageManagementClient
    /// Version: 2021-04-01
    /// </summary>
    public interface IMicrosoftStorageApi
    {
        [Query("api-version")]
        string ApiVersion { get; set; }

        /// <summary>
        /// Lists all of the available Storage Rest API operations.
        ///
        /// OperationsList (/providers/Microsoft.Storage/operations)
        /// </summary>
        [Get("/providers/Microsoft.Storage/operations")]
        Task<OperationListResult> OperationsListAsync();

        /// <summary>
        /// Lists the available SKUs supported by Microsoft.Storage for given subscription.
        ///
        /// SkusList (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/skus)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/skus")]
        Task<StorageSkuListResult> SkusListAsync([Path] string subscriptionId);

        /// <summary>
        /// Checks that the storage account name is valid and is not already in use.
        ///
        /// StorageAccountsCheckNameAvailability (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/checkNameAvailability)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="content">The parameters used to check the availability of the storage account name.</param>
        [Post("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/checkNameAvailability")]
        [Header("Content-Type", "application/json")]
        Task<CheckNameAvailabilityResult> StorageAccountsCheckNameAvailabilityAsync([Path] string subscriptionId, [Body] StorageAccountCheckNameAvailabilityParameters content);

        /// <summary>
        /// Asynchronously creates a new storage account with the specified parameters. If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated. If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed.
        ///
        /// StorageAccountsCreate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="content">The parameters used when creating a storage account.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<StorageAccount, object>>> StorageAccountsCreateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Body] StorageAccountCreateParameters content);

        /// <summary>
        /// Deletes a storage account in Microsoft Azure.
        ///
        /// StorageAccountsDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}")]
        Task<object> StorageAccountsDeleteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// Returns the properties for the specified storage account including but not limited to name, SKU name, location, and account status. The ListKeys operation should be used to retrieve storage keys.
        ///
        /// StorageAccountsGetProperties (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="expand">May be used to expand the properties within account's properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}")]
        Task<StorageAccount> StorageAccountsGetPropertiesAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Query(Name = "$expand")] string expand);

        /// <summary>
        /// The update operation can be used to update the SKU, encryption, access tier, or tags for a storage account. It can also be used to map the account to a custom domain. Only one custom domain is supported per storage account; the replacement/change of custom domain is not supported. In order to replace an old custom domain, the old value must be cleared/unregistered before a new value can be set. The update of multiple properties is supported. This call does not change the storage keys for the account. If you want to change the storage account keys, use the regenerate keys operation. The location and name of the storage account cannot be changed after creation.
        ///
        /// StorageAccountsUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="content">The parameters that can be provided when updating the storage account properties.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}")]
        [Header("Content-Type", "application/json")]
        Task<StorageAccount> StorageAccountsUpdateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Body] StorageAccountUpdateParameters content);

        /// <summary>
        /// Lists deleted accounts under the subscription.
        ///
        /// DeletedAccountsList (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/deletedAccounts)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/deletedAccounts")]
        Task<Response<AnyOf<DeletedAccountListResult, ErrorResponse>>> DeletedAccountsListAsync([Path] string subscriptionId);

        /// <summary>
        /// Get properties of specified deleted account resource.
        ///
        /// DeletedAccountsGet (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="location">The location of the deleted storage account.</param>
        /// <param name="deletedAccountName">Name of the deleted storage account.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}")]
        Task<Response<AnyOf<DeletedAccount, ErrorResponse>>> DeletedAccountsGetAsync([Path] string subscriptionId, [Path] string location, [Path] string deletedAccountName);

        /// <summary>
        /// Lists all the storage accounts available under the subscription. Note that storage keys are not returned; use the ListKeys operation for this.
        ///
        /// StorageAccountsList (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/storageAccounts)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/storageAccounts")]
        Task<StorageAccountListResult> StorageAccountsListAsync([Path] string subscriptionId);

        /// <summary>
        /// Lists all the storage accounts available under the given resource group. Note that storage keys are not returned; use the ListKeys operation for this.
        ///
        /// StorageAccountsListByResourceGroup (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts")]
        Task<StorageAccountListResult> StorageAccountsListByResourceGroupAsync([Path] string subscriptionId, [Path] string resourceGroupName);

        /// <summary>
        /// Lists the access keys or Kerberos keys (if active directory enabled) for the specified storage account.
        ///
        /// StorageAccountsListKeys (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/listKeys)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="expand">Specifies type of the key to be listed. Possible value is kerb.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/listKeys")]
        Task<StorageAccountListKeysResult> StorageAccountsListKeysAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Query(Name = "$expand")] string expand);

        /// <summary>
        /// Regenerates one of the access keys or Kerberos keys for the specified storage account.
        ///
        /// StorageAccountsRegenerateKey (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/regenerateKey)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="content">The parameters used to regenerate the storage account key.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/regenerateKey")]
        [Header("Content-Type", "application/json")]
        Task<StorageAccountListKeysResult> StorageAccountsRegenerateKeyAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Body] StorageAccountRegenerateKeyParameters content);

        /// <summary>
        /// Gets the current usage count and the limit for the resources of the location under the subscription.
        ///
        /// UsagesListByLocation (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/usages)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="location">The location of the Azure Storage resource.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/usages")]
        Task<UsageListResult> UsagesListByLocationAsync([Path] string subscriptionId, [Path] string location);

        /// <summary>
        /// List SAS credentials of a storage account.
        ///
        /// StorageAccountsListAccountSAS (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListAccountSas)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="content">The parameters to list SAS credentials of a storage account.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListAccountSas")]
        [Header("Content-Type", "application/json")]
        Task<ListAccountSasResponse> StorageAccountsListAccountSASAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Body] AccountSasParameters content);

        /// <summary>
        /// List service SAS credentials of a specific resource.
        ///
        /// StorageAccountsListServiceSAS (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListServiceSas)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="content">The parameters to list service SAS credentials of a specific resource.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListServiceSas")]
        [Header("Content-Type", "application/json")]
        Task<ListServiceSasResponse> StorageAccountsListServiceSASAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Body] ServiceSasParameters content);

        /// <summary>
        /// Failover request can be triggered for a storage account in case of availability issues. The failover occurs from the storage account's primary cluster to secondary cluster for RA-GRS accounts. The secondary cluster will become primary after failover.
        ///
        /// StorageAccountsFailover (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/failover)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/failover")]
        Task<object> StorageAccountsFailoverAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// Restore blobs in the specified blob ranges
        ///
        /// StorageAccountsRestoreBlobRanges (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/restoreBlobRanges)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="content">Blob restore parameters</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/restoreBlobRanges")]
        [Header("Content-Type", "application/json")]
        Task<BlobRestoreStatus> StorageAccountsRestoreBlobRangesAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Body] BlobRestoreParameters content);

        /// <summary>
        /// Gets the managementpolicy associated with the specified storage account.
        ///
        /// ManagementPoliciesGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="managementPolicyName">The name of the Storage Account Management Policy. It should always be 'default'</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}")]
        Task<ManagementPolicy> ManagementPoliciesGetAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string managementPolicyName);

        /// <summary>
        /// Sets the managementpolicy to the specified storage account.
        ///
        /// ManagementPoliciesCreateOrUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="managementPolicyName">The name of the Storage Account Management Policy. It should always be 'default'</param>
        /// <param name="content">The Get Storage Account ManagementPolicies operation response.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}")]
        [Header("Content-Type", "application/json")]
        Task<ManagementPolicy> ManagementPoliciesCreateOrUpdateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string managementPolicyName, [Body] ManagementPolicy content);

        /// <summary>
        /// Deletes the managementpolicy associated with the specified storage account.
        ///
        /// ManagementPoliciesDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="managementPolicyName">The name of the Storage Account Management Policy. It should always be 'default'</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}")]
        Task<object> ManagementPoliciesDeleteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string managementPolicyName);

        /// <summary>
        /// Gets the blob inventory policy associated with the specified storage account.
        ///
        /// BlobInventoryPoliciesGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="blobInventoryPolicyName">The name of the storage account blob inventory policy. It should always be 'default'</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}")]
        Task<Response<AnyOf<BlobInventoryPolicy, ErrorResponse>>> BlobInventoryPoliciesGetAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string blobInventoryPolicyName);

        /// <summary>
        /// Sets the blob inventory policy to the specified storage account.
        ///
        /// BlobInventoryPoliciesCreateOrUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="blobInventoryPolicyName">The name of the storage account blob inventory policy. It should always be 'default'</param>
        /// <param name="content">The storage account blob inventory policy.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<BlobInventoryPolicy, ErrorResponse>>> BlobInventoryPoliciesCreateOrUpdateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string blobInventoryPolicyName, [Body] BlobInventoryPolicy content);

        /// <summary>
        /// Deletes the blob inventory policy associated with the specified storage account.
        ///
        /// BlobInventoryPoliciesDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="blobInventoryPolicyName">The name of the storage account blob inventory policy. It should always be 'default'</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}")]
        Task<Response<AnyOf<object, ErrorResponse>>> BlobInventoryPoliciesDeleteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string blobInventoryPolicyName);

        /// <summary>
        /// Gets the blob inventory policy associated with the specified storage account.
        ///
        /// BlobInventoryPoliciesList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies")]
        Task<Response<AnyOf<ListBlobInventoryPolicy, ErrorResponse>>> BlobInventoryPoliciesListAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// List all the private endpoint connections associated with the storage account.
        ///
        /// PrivateEndpointConnectionsList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections")]
        Task<PrivateEndpointConnectionListResult> PrivateEndpointConnectionsListAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// Gets the specified private endpoint connection associated with the storage account.
        ///
        /// PrivateEndpointConnectionsGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="privateEndpointConnectionName">The name of the private endpoint connection associated with the Azure resource</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}")]
        Task<Response<AnyOf<PrivateEndpointConnection, ErrorResponse>>> PrivateEndpointConnectionsGetAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string privateEndpointConnectionName);

        /// <summary>
        /// Update the state of specified private endpoint connection associated with the storage account.
        ///
        /// PrivateEndpointConnectionsPut (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="privateEndpointConnectionName">The name of the private endpoint connection associated with the Azure resource</param>
        /// <param name="content">The private endpoint connection properties.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PrivateEndpointConnection, ErrorResponse>>> PrivateEndpointConnectionsPutAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string privateEndpointConnectionName, [Body] PrivateEndpointConnection content);

        /// <summary>
        /// Deletes the specified private endpoint connection associated with the storage account.
        ///
        /// PrivateEndpointConnectionsDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="privateEndpointConnectionName">The name of the private endpoint connection associated with the Azure resource</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}")]
        Task<Response<AnyOf<object, ErrorResponse>>> PrivateEndpointConnectionsDeleteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string privateEndpointConnectionName);

        /// <summary>
        /// Gets the private link resources that need to be created for a storage account.
        ///
        /// PrivateLinkResourcesListByStorageAccount (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateLinkResources)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateLinkResources")]
        Task<PrivateLinkResourceListResult> PrivateLinkResourcesListByStorageAccountAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// List the object replication policies associated with the storage account.
        ///
        /// ObjectReplicationPoliciesList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies")]
        Task<Response<AnyOf<ObjectReplicationPolicies, ErrorResponse>>> ObjectReplicationPoliciesListAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// Get the object replication policy of the storage account by policy ID.
        ///
        /// ObjectReplicationPoliciesGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="objectReplicationPolicyId">For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}")]
        Task<Response<AnyOf<ObjectReplicationPolicy, ErrorResponse>>> ObjectReplicationPoliciesGetAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string objectReplicationPolicyId);

        /// <summary>
        /// Create or update the object replication policy of the storage account.
        ///
        /// ObjectReplicationPoliciesCreateOrUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="objectReplicationPolicyId">For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file.</param>
        /// <param name="content">The replication policy between two storage accounts. Multiple rules can be defined in one policy.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ObjectReplicationPolicy, ErrorResponse>>> ObjectReplicationPoliciesCreateOrUpdateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string objectReplicationPolicyId, [Body] ObjectReplicationPolicy content);

        /// <summary>
        /// Deletes the object replication policy associated with the specified storage account.
        ///
        /// ObjectReplicationPoliciesDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="objectReplicationPolicyId">For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}")]
        Task<Response<AnyOf<object, ErrorResponse>>> ObjectReplicationPoliciesDeleteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string objectReplicationPolicyId);

        /// <summary>
        /// Revoke user delegation keys.
        ///
        /// StorageAccountsRevokeUserDelegationKeys (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/revokeUserDelegationKeys)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/revokeUserDelegationKeys")]
        Task<object> StorageAccountsRevokeUserDelegationKeysAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// Synchronously creates or updates an encryption scope under the specified storage account. If an encryption scope is already created and a subsequent request is issued with different properties, the encryption scope properties will be updated per the specified request.
        ///
        /// EncryptionScopesPut (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="encryptionScopeName">The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <param name="content">The Encryption Scope resource.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<EncryptionScope, ErrorResponse>>> EncryptionScopesPutAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string encryptionScopeName, [Body] EncryptionScope content);

        /// <summary>
        /// Update encryption scope properties as specified in the request body. Update fails if the specified encryption scope does not already exist.
        ///
        /// EncryptionScopesPatch (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="encryptionScopeName">The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <param name="content">The Encryption Scope resource.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<EncryptionScope, ErrorResponse>>> EncryptionScopesPatchAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string encryptionScopeName, [Body] EncryptionScope content);

        /// <summary>
        /// Returns the properties for the specified encryption scope.
        ///
        /// EncryptionScopesGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="encryptionScopeName">The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}")]
        Task<Response<AnyOf<EncryptionScope, ErrorResponse>>> EncryptionScopesGetAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string encryptionScopeName);

        /// <summary>
        /// Lists all the encryption scopes available under the specified storage account.
        ///
        /// EncryptionScopesList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes")]
        Task<EncryptionScopeListResult> EncryptionScopesListAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);
    }
}