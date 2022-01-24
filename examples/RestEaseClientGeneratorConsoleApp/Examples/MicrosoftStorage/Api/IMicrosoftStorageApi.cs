using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnyOfTypes;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Api
{
    /// <summary>
    /// The Azure Storage Management API.
    /// </summary>
    public interface IMicrosoftStorageApi
    {
        [Query("api-version")]
        string ApiVersion { get; set; }

        /// <summary>
        /// OperationsList (/providers/Microsoft.Storage/operations)
        /// </summary>
        [Get("/providers/Microsoft.Storage/operations?")]
        Task<OperationListResult> OperationsListAsync();

        /// <summary>
        /// SkusList (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/skus)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/skus?")]
        Task<StorageSkuListResult> SkusListAsync([Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsCheckNameAvailability (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/checkNameAvailability)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="content">The parameters used to check the availability of the storage account name.</param>
        [Post("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/checkNameAvailability?")]
        [Header("Content-Type", "application/json")]
        Task<CheckNameAvailabilityResult> StorageAccountsCheckNameAvailabilityAsync([Path] string subscriptionId, [Body] StorageAccountCheckNameAvailabilityParameters content);

        /// <summary>
        /// StorageAccountsCreate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="content">The parameters used when creating a storage account.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}?")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<StorageAccount, object>>> StorageAccountsCreateAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Body] StorageAccountCreateParameters content);

        /// <summary>
        /// StorageAccountsDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}?")]
        Task<object> StorageAccountsDeleteAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsGetProperties (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="expand">May be used to expand the properties within account's properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}?")]
        Task<StorageAccount> StorageAccountsGetPropertiesAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Query(Name = "$expand")] string expand);

        /// <summary>
        /// StorageAccountsUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="content">The parameters that can be provided when updating the storage account properties.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}?")]
        [Header("Content-Type", "application/json")]
        Task<StorageAccount> StorageAccountsUpdateAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Body] StorageAccountUpdateParameters content);

        /// <summary>
        /// DeletedAccountsList (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/deletedAccounts)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/deletedAccounts?")]
        Task<Response<AnyOf<DeletedAccountListResult, ErrorResponse>>> DeletedAccountsListAsync([Path] string subscriptionId);

        /// <summary>
        /// DeletedAccountsGet (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName})
        /// </summary>
        /// <param name="location">The location of the deleted storage account.</param>
        /// <param name="deletedAccountName">Name of the deleted storage account.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}?")]
        Task<Response<AnyOf<DeletedAccount, ErrorResponse>>> DeletedAccountsGetAsync([Path] string location, [Path] string deletedAccountName, [Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsList (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/storageAccounts)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/storageAccounts?")]
        Task<StorageAccountListResult> StorageAccountsListAsync([Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsListByResourceGroup (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts)
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts?")]
        Task<StorageAccountListResult> StorageAccountsListByResourceGroupAsync([Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsListKeys (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/listKeys)
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="expand">Specifies type of the key to be listed. Possible value is kerb.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/listKeys?")]
        Task<StorageAccountListKeysResult> StorageAccountsListKeysAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Query(Name = "$expand")] string expand);

        /// <summary>
        /// StorageAccountsRegenerateKey (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/regenerateKey)
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="content">The parameters used to regenerate the storage account key.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/regenerateKey?")]
        [Header("Content-Type", "application/json")]
        Task<StorageAccountListKeysResult> StorageAccountsRegenerateKeyAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Body] StorageAccountRegenerateKeyParameters content);

        /// <summary>
        /// UsagesListByLocation (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/usages)
        /// </summary>
        /// <param name="location">The location of the Azure Storage resource.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/usages?")]
        Task<UsageListResult> UsagesListByLocationAsync([Path] string location, [Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsListAccountSAS (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListAccountSas)
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="content">The parameters to list SAS credentials of a storage account.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListAccountSas?")]
        [Header("Content-Type", "application/json")]
        Task<ListAccountSasResponse> StorageAccountsListAccountSASAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Body] AccountSasParameters content);

        /// <summary>
        /// StorageAccountsListServiceSAS (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListServiceSas)
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="content">The parameters to list service SAS credentials of a specific resource.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListServiceSas?")]
        [Header("Content-Type", "application/json")]
        Task<ListServiceSasResponse> StorageAccountsListServiceSASAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Body] ServiceSasParameters content);

        /// <summary>
        /// StorageAccountsFailover (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/failover)
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/failover?")]
        Task<object> StorageAccountsFailoverAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsHierarchicalNamespaceMigration (/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/hnsonmigration)
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="requestType">Required. Hierarchical namespace migration type can either be a hierarchical namespace validation request 'HnsOnValidationRequest' or a hydration request 'HnsOnHydrationRequest'. The validation request will validate the migration whereas the hydration request will migrate the account.</param>
        [Post("/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/hnsonmigration?")]
        Task<Response<AnyOf<object, ErrorResponse>>> StorageAccountsHierarchicalNamespaceMigrationAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Query] string requestType);

        /// <summary>
        /// StorageAccountsAbortHierarchicalNamespaceMigration (/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/aborthnsonmigration)
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Post("/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/aborthnsonmigration?")]
        Task<Response<AnyOf<object, ErrorResponse>>> StorageAccountsAbortHierarchicalNamespaceMigrationAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsRestoreBlobRanges (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/restoreBlobRanges)
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="content">Blob restore parameters</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/restoreBlobRanges?")]
        [Header("Content-Type", "application/json")]
        Task<BlobRestoreStatus> StorageAccountsRestoreBlobRangesAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Body] BlobRestoreParameters content);

        /// <summary>
        /// ManagementPoliciesGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="managementPolicyName">The name of the Storage Account Management Policy. It should always be 'default'</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}?")]
        Task<ManagementPolicy> ManagementPoliciesGetAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string managementPolicyName);

        /// <summary>
        /// ManagementPoliciesCreateOrUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="managementPolicyName">The name of the Storage Account Management Policy. It should always be 'default'</param>
        /// <param name="content">The Get Storage Account ManagementPolicies operation response.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}?")]
        [Header("Content-Type", "application/json")]
        Task<ManagementPolicy> ManagementPoliciesCreateOrUpdateAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string managementPolicyName, [Body] ManagementPolicy content);

        /// <summary>
        /// ManagementPoliciesDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="managementPolicyName">The name of the Storage Account Management Policy. It should always be 'default'</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}?")]
        Task<object> ManagementPoliciesDeleteAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string managementPolicyName);

        /// <summary>
        /// BlobInventoryPoliciesGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="blobInventoryPolicyName">The name of the storage account blob inventory policy. It should always be 'default'</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}?")]
        Task<Response<AnyOf<BlobInventoryPolicy, ErrorResponse>>> BlobInventoryPoliciesGetAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string blobInventoryPolicyName);

        /// <summary>
        /// BlobInventoryPoliciesCreateOrUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="blobInventoryPolicyName">The name of the storage account blob inventory policy. It should always be 'default'</param>
        /// <param name="content">The storage account blob inventory policy.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}?")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<BlobInventoryPolicy, ErrorResponse>>> BlobInventoryPoliciesCreateOrUpdateAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string blobInventoryPolicyName, [Body] BlobInventoryPolicy content);

        /// <summary>
        /// BlobInventoryPoliciesDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="blobInventoryPolicyName">The name of the storage account blob inventory policy. It should always be 'default'</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}?")]
        Task<Response<AnyOf<object, ErrorResponse>>> BlobInventoryPoliciesDeleteAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string blobInventoryPolicyName);

        /// <summary>
        /// BlobInventoryPoliciesList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies)
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies?")]
        Task<Response<AnyOf<ListBlobInventoryPolicy, ErrorResponse>>> BlobInventoryPoliciesListAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId);

        /// <summary>
        /// PrivateEndpointConnectionsList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections)
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections?")]
        Task<PrivateEndpointConnectionListResult> PrivateEndpointConnectionsListAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId);

        /// <summary>
        /// PrivateEndpointConnectionsGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="privateEndpointConnectionName">The name of the private endpoint connection associated with the Azure resource</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}?")]
        Task<Response<AnyOf<PrivateEndpointConnection, ErrorResponse>>> PrivateEndpointConnectionsGetAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string privateEndpointConnectionName);

        /// <summary>
        /// PrivateEndpointConnectionsPut (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="privateEndpointConnectionName">The name of the private endpoint connection associated with the Azure resource</param>
        /// <param name="content">The private endpoint connection properties.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}?")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PrivateEndpointConnection, ErrorResponse>>> PrivateEndpointConnectionsPutAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string privateEndpointConnectionName, [Body] PrivateEndpointConnection content);

        /// <summary>
        /// PrivateEndpointConnectionsDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="privateEndpointConnectionName">The name of the private endpoint connection associated with the Azure resource</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}?")]
        Task<Response<AnyOf<object, ErrorResponse>>> PrivateEndpointConnectionsDeleteAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string privateEndpointConnectionName);

        /// <summary>
        /// PrivateLinkResourcesListByStorageAccount (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateLinkResources)
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateLinkResources?")]
        Task<PrivateLinkResourceListResult> PrivateLinkResourcesListByStorageAccountAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId);

        /// <summary>
        /// ObjectReplicationPoliciesList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies)
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies?")]
        Task<Response<AnyOf<ObjectReplicationPolicies, ErrorResponse>>> ObjectReplicationPoliciesListAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId);

        /// <summary>
        /// ObjectReplicationPoliciesGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="objectReplicationPolicyId">For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}?")]
        Task<Response<AnyOf<ObjectReplicationPolicy, ErrorResponse>>> ObjectReplicationPoliciesGetAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string objectReplicationPolicyId);

        /// <summary>
        /// ObjectReplicationPoliciesCreateOrUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="objectReplicationPolicyId">For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file.</param>
        /// <param name="content">The replication policy between two storage accounts. Multiple rules can be defined in one policy.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}?")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ObjectReplicationPolicy, ErrorResponse>>> ObjectReplicationPoliciesCreateOrUpdateAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string objectReplicationPolicyId, [Body] ObjectReplicationPolicy content);

        /// <summary>
        /// ObjectReplicationPoliciesDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="objectReplicationPolicyId">For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}?")]
        Task<Response<AnyOf<object, ErrorResponse>>> ObjectReplicationPoliciesDeleteAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string objectReplicationPolicyId);

        /// <summary>
        /// StorageAccountsRevokeUserDelegationKeys (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/revokeUserDelegationKeys)
        /// </summary>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/revokeUserDelegationKeys?")]
        Task<object> StorageAccountsRevokeUserDelegationKeysAsync([Path] string accountName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// LocalUsersList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers)
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers?")]
        Task<Response<AnyOf<LocalUsers, ErrorResponse>>> LocalUsersListAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId);

        /// <summary>
        /// LocalUsersGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="username">The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}?")]
        Task<Response<AnyOf<LocalUser, ErrorResponse>>> LocalUsersGetAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string username);

        /// <summary>
        /// LocalUsersCreateOrUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="username">The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account.</param>
        /// <param name="content">The local user associated with the storage accounts.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}?")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<LocalUser, ErrorResponse>>> LocalUsersCreateOrUpdateAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string username, [Body] LocalUser content);

        /// <summary>
        /// LocalUsersDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="username">The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}?")]
        Task<Response<AnyOf<object, ErrorResponse>>> LocalUsersDeleteAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string username);

        /// <summary>
        /// LocalUsersListKeys (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}/listKeys)
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="username">The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}/listKeys?")]
        Task<Response<AnyOf<LocalUserKeys, ErrorResponse>>> LocalUsersListKeysAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string username);

        /// <summary>
        /// LocalUsersRegeneratePassword (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}/regeneratePassword)
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="username">The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}/regeneratePassword?")]
        Task<Response<AnyOf<LocalUserRegeneratePasswordResult, ErrorResponse>>> LocalUsersRegeneratePasswordAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string username);

        /// <summary>
        /// EncryptionScopesPut (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="encryptionScopeName">The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <param name="content">The Encryption Scope resource.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}?")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<EncryptionScope, ErrorResponse>>> EncryptionScopesPutAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string encryptionScopeName, [Body] EncryptionScope content);

        /// <summary>
        /// EncryptionScopesPatch (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="encryptionScopeName">The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <param name="content">The Encryption Scope resource.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}?")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<EncryptionScope, ErrorResponse>>> EncryptionScopesPatchAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string encryptionScopeName, [Body] EncryptionScope content);

        /// <summary>
        /// EncryptionScopesGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName})
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="encryptionScopeName">The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}?")]
        Task<Response<AnyOf<EncryptionScope, ErrorResponse>>> EncryptionScopesGetAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId, [Path] string encryptionScopeName);

        /// <summary>
        /// EncryptionScopesList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes)
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes?")]
        Task<EncryptionScopeListResult> EncryptionScopesListAsync([Path] string resourceGroupName, [Path] string accountName, [Path] string subscriptionId);
    }
}