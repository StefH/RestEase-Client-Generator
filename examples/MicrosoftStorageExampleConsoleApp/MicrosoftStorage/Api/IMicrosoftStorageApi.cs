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
    /// The Azure Storage Management API.
    /// </summary>
    public interface IMicrosoftStorageApi
    {
        /// <summary>
        /// OperationsList (/providers/Microsoft.Storage/operations)
        /// </summary>
        [Get("/providers/Microsoft.Storage/operations?api-version=2021-04-01")]
        Task<OperationListResult> OperationsListAsync();

        /// <summary>
        /// SkusList (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/skus)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/skus?api-version=2021-04-01")]
        Task<StorageSkuListResult> SkusListAsync([Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsCheckNameAvailability (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/checkNameAvailability)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="content">The parameters used to check the availability of the storage account name.</param>
        [Post("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/checkNameAvailability?api-version=2021-04-01")]
        [Header("Content-Type", "application/json")]
        Task<CheckNameAvailabilityResult> StorageAccountsCheckNameAvailabilityAsync([Path] string subscriptionId, [Body] StorageAccountCheckNameAvailabilityParameters content);

        /// <summary>
        /// StorageAccountsCreate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="content">The parameters used when creating a storage account.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}?api-version=2021-04-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<StorageAccount, object>>> StorageAccountsCreateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Body] StorageAccountCreateParameters content);

        /// <summary>
        /// StorageAccountsDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}?api-version=2021-04-01")]
        Task<object> StorageAccountsDeleteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// StorageAccountsGetProperties (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="expand">May be used to expand the properties within account's properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}?api-version=2021-04-01")]
        Task<StorageAccount> StorageAccountsGetPropertiesAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Query(Name = "$expand")] string expand);

        /// <summary>
        /// StorageAccountsUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="content">The parameters that can be provided when updating the storage account properties.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}?api-version=2021-04-01")]
        [Header("Content-Type", "application/json")]
        Task<StorageAccount> StorageAccountsUpdateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Body] StorageAccountUpdateParameters content);

        /// <summary>
        /// DeletedAccountsList (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/deletedAccounts)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/deletedAccounts?api-version=2021-04-01")]
        Task<Response<AnyOf<DeletedAccountListResult, ErrorResponse>>> DeletedAccountsListAsync([Path] string subscriptionId);

        /// <summary>
        /// DeletedAccountsGet (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="location">The location of the deleted storage account.</param>
        /// <param name="deletedAccountName">Name of the deleted storage account.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}?api-version=2021-04-01")]
        Task<Response<AnyOf<DeletedAccount, ErrorResponse>>> DeletedAccountsGetAsync([Path] string subscriptionId, [Path] string location, [Path] string deletedAccountName);

        /// <summary>
        /// StorageAccountsList (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/storageAccounts)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/storageAccounts?api-version=2021-04-01")]
        Task<StorageAccountListResult> StorageAccountsListAsync([Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsListByResourceGroup (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts?api-version=2021-04-01")]
        Task<StorageAccountListResult> StorageAccountsListByResourceGroupAsync([Path] string subscriptionId, [Path] string resourceGroupName);

        /// <summary>
        /// StorageAccountsListKeys (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/listKeys)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="expand">Specifies type of the key to be listed. Possible value is kerb.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/listKeys?api-version=2021-04-01")]
        Task<StorageAccountListKeysResult> StorageAccountsListKeysAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Query(Name = "$expand")] string expand);

        /// <summary>
        /// StorageAccountsRegenerateKey (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/regenerateKey)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="content">The parameters used to regenerate the storage account key.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/regenerateKey?api-version=2021-04-01")]
        [Header("Content-Type", "application/json")]
        Task<StorageAccountListKeysResult> StorageAccountsRegenerateKeyAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Body] StorageAccountRegenerateKeyParameters content);

        /// <summary>
        /// UsagesListByLocation (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/usages)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="location">The location of the Azure Storage resource.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/usages?api-version=2021-04-01")]
        Task<UsageListResult> UsagesListByLocationAsync([Path] string subscriptionId, [Path] string location);

        /// <summary>
        /// StorageAccountsListAccountSAS (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListAccountSas)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="content">The parameters to list SAS credentials of a storage account.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListAccountSas?api-version=2021-04-01")]
        [Header("Content-Type", "application/json")]
        Task<ListAccountSasResponse> StorageAccountsListAccountSASAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Body] AccountSasParameters content);

        /// <summary>
        /// StorageAccountsListServiceSAS (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListServiceSas)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="content">The parameters to list service SAS credentials of a specific resource.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListServiceSas?api-version=2021-04-01")]
        [Header("Content-Type", "application/json")]
        Task<ListServiceSasResponse> StorageAccountsListServiceSASAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Body] ServiceSasParameters content);

        /// <summary>
        /// StorageAccountsFailover (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/failover)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/failover?api-version=2021-04-01")]
        Task<object> StorageAccountsFailoverAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// StorageAccountsRestoreBlobRanges (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/restoreBlobRanges)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="content">Blob restore parameters</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/restoreBlobRanges?api-version=2021-04-01")]
        [Header("Content-Type", "application/json")]
        Task<BlobRestoreStatus> StorageAccountsRestoreBlobRangesAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Body] BlobRestoreParameters content);

        /// <summary>
        /// ManagementPoliciesGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="managementPolicyName">The name of the Storage Account Management Policy. It should always be 'default'</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}?api-version=2021-04-01")]
        Task<ManagementPolicy> ManagementPoliciesGetAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string managementPolicyName);

        /// <summary>
        /// ManagementPoliciesCreateOrUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="managementPolicyName">The name of the Storage Account Management Policy. It should always be 'default'</param>
        /// <param name="content">The Get Storage Account ManagementPolicies operation response.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}?api-version=2021-04-01")]
        [Header("Content-Type", "application/json")]
        Task<ManagementPolicy> ManagementPoliciesCreateOrUpdateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string managementPolicyName, [Body] ManagementPolicy content);

        /// <summary>
        /// ManagementPoliciesDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="managementPolicyName">The name of the Storage Account Management Policy. It should always be 'default'</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}?api-version=2021-04-01")]
        Task<object> ManagementPoliciesDeleteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string managementPolicyName);

        /// <summary>
        /// BlobInventoryPoliciesGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="blobInventoryPolicyName">The name of the storage account blob inventory policy. It should always be 'default'</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}?api-version=2021-04-01")]
        Task<Response<AnyOf<BlobInventoryPolicy, ErrorResponse>>> BlobInventoryPoliciesGetAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string blobInventoryPolicyName);

        /// <summary>
        /// BlobInventoryPoliciesCreateOrUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="blobInventoryPolicyName">The name of the storage account blob inventory policy. It should always be 'default'</param>
        /// <param name="content">The storage account blob inventory policy.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}?api-version=2021-04-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<BlobInventoryPolicy, ErrorResponse>>> BlobInventoryPoliciesCreateOrUpdateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string blobInventoryPolicyName, [Body] BlobInventoryPolicy content);

        /// <summary>
        /// BlobInventoryPoliciesDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="blobInventoryPolicyName">The name of the storage account blob inventory policy. It should always be 'default'</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}?api-version=2021-04-01")]
        Task<Response<AnyOf<object, ErrorResponse>>> BlobInventoryPoliciesDeleteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string blobInventoryPolicyName);

        /// <summary>
        /// BlobInventoryPoliciesList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies?api-version=2021-04-01")]
        Task<Response<AnyOf<ListBlobInventoryPolicy, ErrorResponse>>> BlobInventoryPoliciesListAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// PrivateEndpointConnectionsList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections?api-version=2021-04-01")]
        Task<PrivateEndpointConnectionListResult> PrivateEndpointConnectionsListAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// PrivateEndpointConnectionsGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="privateEndpointConnectionName">The name of the private endpoint connection associated with the Azure resource</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}?api-version=2021-04-01")]
        Task<Response<AnyOf<PrivateEndpointConnection, ErrorResponse>>> PrivateEndpointConnectionsGetAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string privateEndpointConnectionName);

        /// <summary>
        /// PrivateEndpointConnectionsPut (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="privateEndpointConnectionName">The name of the private endpoint connection associated with the Azure resource</param>
        /// <param name="content">The private endpoint connection properties.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}?api-version=2021-04-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PrivateEndpointConnection, ErrorResponse>>> PrivateEndpointConnectionsPutAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string privateEndpointConnectionName, [Body] PrivateEndpointConnection content);

        /// <summary>
        /// PrivateEndpointConnectionsDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="privateEndpointConnectionName">The name of the private endpoint connection associated with the Azure resource</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}?api-version=2021-04-01")]
        Task<Response<AnyOf<object, ErrorResponse>>> PrivateEndpointConnectionsDeleteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string privateEndpointConnectionName);

        /// <summary>
        /// PrivateLinkResourcesListByStorageAccount (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateLinkResources)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateLinkResources?api-version=2021-04-01")]
        Task<PrivateLinkResourceListResult> PrivateLinkResourcesListByStorageAccountAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// ObjectReplicationPoliciesList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies?api-version=2021-04-01")]
        Task<Response<AnyOf<ObjectReplicationPolicies, ErrorResponse>>> ObjectReplicationPoliciesListAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// ObjectReplicationPoliciesGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="objectReplicationPolicyId">For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}?api-version=2021-04-01")]
        Task<Response<AnyOf<ObjectReplicationPolicy, ErrorResponse>>> ObjectReplicationPoliciesGetAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string objectReplicationPolicyId);

        /// <summary>
        /// ObjectReplicationPoliciesCreateOrUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="objectReplicationPolicyId">For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file.</param>
        /// <param name="content">The replication policy between two storage accounts. Multiple rules can be defined in one policy.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}?api-version=2021-04-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ObjectReplicationPolicy, ErrorResponse>>> ObjectReplicationPoliciesCreateOrUpdateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string objectReplicationPolicyId, [Body] ObjectReplicationPolicy content);

        /// <summary>
        /// ObjectReplicationPoliciesDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="objectReplicationPolicyId">For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}?api-version=2021-04-01")]
        Task<Response<AnyOf<object, ErrorResponse>>> ObjectReplicationPoliciesDeleteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string objectReplicationPolicyId);

        /// <summary>
        /// StorageAccountsRevokeUserDelegationKeys (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/revokeUserDelegationKeys)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/revokeUserDelegationKeys?api-version=2021-04-01")]
        Task<object> StorageAccountsRevokeUserDelegationKeysAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);

        /// <summary>
        /// EncryptionScopesPut (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="encryptionScopeName">The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <param name="content">The Encryption Scope resource.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}?api-version=2021-04-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<EncryptionScope, ErrorResponse>>> EncryptionScopesPutAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string encryptionScopeName, [Body] EncryptionScope content);

        /// <summary>
        /// EncryptionScopesPatch (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="encryptionScopeName">The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        /// <param name="content">The Encryption Scope resource.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}?api-version=2021-04-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<EncryptionScope, ErrorResponse>>> EncryptionScopesPatchAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string encryptionScopeName, [Body] EncryptionScope content);

        /// <summary>
        /// EncryptionScopesGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="encryptionScopeName">The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}?api-version=2021-04-01")]
        Task<Response<AnyOf<EncryptionScope, ErrorResponse>>> EncryptionScopesGetAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName, [Path] string encryptionScopeName);

        /// <summary>
        /// EncryptionScopesList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes?api-version=2021-04-01")]
        Task<EncryptionScopeListResult> EncryptionScopesListAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string accountName);
    }
}