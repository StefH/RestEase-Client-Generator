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
        [Query("api-version")]
        string ApiVersion { get; set; }

        /// <summary>
        /// OperationsList (/providers/Microsoft.Storage/operations)
        /// </summary>
        [Get("/providers/Microsoft.Storage/operations")]
        Task<OperationListResult> OperationsListAsync();

        /// <summary>
        /// SkusList (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/skus)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/skus")]
        Task<StorageSkuListResult> SkusListAsync([Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsCheckNameAvailability (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/checkNameAvailability)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Post("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/checkNameAvailability")]
        [Header("Content-Type", "application/json")]
        Task<CheckNameAvailabilityResult> StorageAccountsCheckNameAvailabilityAsync([Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsCreate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}")]
        [Header("Content-Type", "application/json")]
        Task<AnyOf<StorageAccount, Response<object>>> StorageAccountsCreateAsync([Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}")]
        Task<Response<object>> StorageAccountsDeleteAsync([Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsGetProperties (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="expand">May be used to expand the properties within account's properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}")]
        Task<StorageAccount> StorageAccountsGetPropertiesAsync([Path] string subscriptionId, [Query(Name = "$expand")] string expand);

        /// <summary>
        /// StorageAccountsUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}")]
        [Header("Content-Type", "application/json")]
        Task<StorageAccount> StorageAccountsUpdateAsync([Path] string subscriptionId);

        /// <summary>
        /// DeletedAccountsList (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/deletedAccounts)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/deletedAccounts")]
        Task<AnyOf<DeletedAccountListResult, ErrorResponse>> DeletedAccountsListAsync([Path] string subscriptionId);

        /// <summary>
        /// DeletedAccountsGet (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName})
        /// </summary>
        /// <param name="location">The location of the deleted storage account.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}")]
        Task<AnyOf<DeletedAccount, ErrorResponse>> DeletedAccountsGetAsync([Path] string location, [Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsList (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/storageAccounts)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/storageAccounts")]
        Task<StorageAccountListResult> StorageAccountsListAsync([Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsListByResourceGroup (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts")]
        Task<StorageAccountListResult> StorageAccountsListByResourceGroupAsync([Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsListKeys (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/listKeys)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="expand">Specifies type of the key to be listed. Possible value is kerb.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/listKeys")]
        Task<StorageAccountListKeysResult> StorageAccountsListKeysAsync([Path] string subscriptionId, [Query(Name = "$expand")] string expand);

        /// <summary>
        /// StorageAccountsRegenerateKey (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/regenerateKey)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/regenerateKey")]
        [Header("Content-Type", "application/json")]
        Task<StorageAccountListKeysResult> StorageAccountsRegenerateKeyAsync([Path] string subscriptionId);

        /// <summary>
        /// UsagesListByLocation (/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/usages)
        /// </summary>
        /// <param name="location">The location of the Azure Storage resource.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/usages")]
        Task<UsageListResult> UsagesListByLocationAsync([Path] string location, [Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsListAccountSAS (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListAccountSas)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListAccountSas")]
        [Header("Content-Type", "application/json")]
        Task<ListAccountSasResponse> StorageAccountsListAccountSASAsync([Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsListServiceSAS (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListServiceSas)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/ListServiceSas")]
        [Header("Content-Type", "application/json")]
        Task<ListServiceSasResponse> StorageAccountsListServiceSASAsync([Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsFailover (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/failover)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/failover")]
        Task<Response<object>> StorageAccountsFailoverAsync([Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsHierarchicalNamespaceMigration (/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/hnsonmigration)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="requestType">Required. Hierarchical namespace migration type can either be a hierarchical namespace validation request 'HnsOnValidationRequest' or a hydration request 'HnsOnHydrationRequest'. The validation request will validate the migration whereas the hydration request will migrate the account.</param>
        [Post("/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/hnsonmigration")]
        Task<AnyOf<Response<object>, ErrorResponse>> StorageAccountsHierarchicalNamespaceMigrationAsync([Path] string subscriptionId, [Query] string requestType);

        /// <summary>
        /// StorageAccountsAbortHierarchicalNamespaceMigration (/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/aborthnsonmigration)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Post("/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/aborthnsonmigration")]
        Task<AnyOf<Response<object>, ErrorResponse>> StorageAccountsAbortHierarchicalNamespaceMigrationAsync([Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsRestoreBlobRanges (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/restoreBlobRanges)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/restoreBlobRanges")]
        [Header("Content-Type", "application/json")]
        Task<BlobRestoreStatus> StorageAccountsRestoreBlobRangesAsync([Path] string subscriptionId);

        /// <summary>
        /// ManagementPoliciesGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}")]
        Task<ManagementPolicy> ManagementPoliciesGetAsync([Path] string subscriptionId);

        /// <summary>
        /// ManagementPoliciesCreateOrUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}")]
        [Header("Content-Type", "application/json")]
        Task<ManagementPolicy> ManagementPoliciesCreateOrUpdateAsync([Path] string subscriptionId);

        /// <summary>
        /// ManagementPoliciesDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}")]
        Task<Response<object>> ManagementPoliciesDeleteAsync([Path] string subscriptionId);

        /// <summary>
        /// BlobInventoryPoliciesGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}")]
        Task<AnyOf<BlobInventoryPolicy, ErrorResponse>> BlobInventoryPoliciesGetAsync([Path] string subscriptionId);

        /// <summary>
        /// BlobInventoryPoliciesCreateOrUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}")]
        [Header("Content-Type", "application/json")]
        Task<AnyOf<BlobInventoryPolicy, ErrorResponse>> BlobInventoryPoliciesCreateOrUpdateAsync([Path] string subscriptionId);

        /// <summary>
        /// BlobInventoryPoliciesDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}")]
        Task<AnyOf<Response<object>, ErrorResponse>> BlobInventoryPoliciesDeleteAsync([Path] string subscriptionId);

        /// <summary>
        /// BlobInventoryPoliciesList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies")]
        Task<AnyOf<ListBlobInventoryPolicy, ErrorResponse>> BlobInventoryPoliciesListAsync([Path] string subscriptionId);

        /// <summary>
        /// PrivateEndpointConnectionsList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections")]
        Task<PrivateEndpointConnectionListResult> PrivateEndpointConnectionsListAsync([Path] string subscriptionId);

        /// <summary>
        /// PrivateEndpointConnectionsGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="privateEndpointConnectionName">The name of the private endpoint connection associated with the Azure resource</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}")]
        Task<AnyOf<PrivateEndpointConnection, ErrorResponse>> PrivateEndpointConnectionsGetAsync([Path] string subscriptionId, [Path] string privateEndpointConnectionName);

        /// <summary>
        /// PrivateEndpointConnectionsPut (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="privateEndpointConnectionName">The name of the private endpoint connection associated with the Azure resource</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}")]
        [Header("Content-Type", "application/json")]
        Task<AnyOf<PrivateEndpointConnection, ErrorResponse>> PrivateEndpointConnectionsPutAsync([Path] string subscriptionId, [Path] string privateEndpointConnectionName);

        /// <summary>
        /// PrivateEndpointConnectionsDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="privateEndpointConnectionName">The name of the private endpoint connection associated with the Azure resource</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}")]
        Task<AnyOf<Response<object>, ErrorResponse>> PrivateEndpointConnectionsDeleteAsync([Path] string subscriptionId, [Path] string privateEndpointConnectionName);

        /// <summary>
        /// PrivateLinkResourcesListByStorageAccount (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateLinkResources)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/privateLinkResources")]
        Task<PrivateLinkResourceListResult> PrivateLinkResourcesListByStorageAccountAsync([Path] string subscriptionId);

        /// <summary>
        /// ObjectReplicationPoliciesList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies")]
        Task<AnyOf<ObjectReplicationPolicies, ErrorResponse>> ObjectReplicationPoliciesListAsync([Path] string subscriptionId);

        /// <summary>
        /// ObjectReplicationPoliciesGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}")]
        Task<AnyOf<ObjectReplicationPolicy, ErrorResponse>> ObjectReplicationPoliciesGetAsync([Path] string subscriptionId);

        /// <summary>
        /// ObjectReplicationPoliciesCreateOrUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}")]
        [Header("Content-Type", "application/json")]
        Task<AnyOf<ObjectReplicationPolicy, ErrorResponse>> ObjectReplicationPoliciesCreateOrUpdateAsync([Path] string subscriptionId);

        /// <summary>
        /// ObjectReplicationPoliciesDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}")]
        Task<AnyOf<Response<object>, ErrorResponse>> ObjectReplicationPoliciesDeleteAsync([Path] string subscriptionId);

        /// <summary>
        /// StorageAccountsRevokeUserDelegationKeys (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/revokeUserDelegationKeys)
        /// </summary>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/revokeUserDelegationKeys")]
        Task<Response<object>> StorageAccountsRevokeUserDelegationKeysAsync([Path] string accountName, [Path] string subscriptionId);

        /// <summary>
        /// LocalUsersList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers")]
        Task<AnyOf<LocalUsers, ErrorResponse>> LocalUsersListAsync([Path] string subscriptionId);

        /// <summary>
        /// LocalUsersGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}")]
        Task<AnyOf<LocalUser, ErrorResponse>> LocalUsersGetAsync([Path] string subscriptionId);

        /// <summary>
        /// LocalUsersCreateOrUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        /// <param name="content">The local user associated with the storage accounts.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}")]
        [Header("Content-Type", "application/json")]
        Task<AnyOf<LocalUser, ErrorResponse>> LocalUsersCreateOrUpdateAsync([Path] string subscriptionId, [Body] LocalUser content);

        /// <summary>
        /// LocalUsersDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}")]
        Task<AnyOf<Response<object>, ErrorResponse>> LocalUsersDeleteAsync([Path] string subscriptionId);

        /// <summary>
        /// LocalUsersListKeys (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}/listKeys)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}/listKeys")]
        Task<AnyOf<LocalUserKeys, ErrorResponse>> LocalUsersListKeysAsync([Path] string subscriptionId);

        /// <summary>
        /// LocalUsersRegeneratePassword (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}/regeneratePassword)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}/regeneratePassword")]
        Task<AnyOf<LocalUserRegeneratePasswordResult, ErrorResponse>> LocalUsersRegeneratePasswordAsync([Path] string subscriptionId);

        /// <summary>
        /// EncryptionScopesPut (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}")]
        [Header("Content-Type", "application/json")]
        Task<AnyOf<EncryptionScope, ErrorResponse>> EncryptionScopesPutAsync([Path] string subscriptionId);

        /// <summary>
        /// EncryptionScopesPatch (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}")]
        [Header("Content-Type", "application/json")]
        Task<AnyOf<EncryptionScope, ErrorResponse>> EncryptionScopesPatchAsync([Path] string subscriptionId);

        /// <summary>
        /// EncryptionScopesGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName})
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}")]
        Task<AnyOf<EncryptionScope, ErrorResponse>> EncryptionScopesGetAsync([Path] string subscriptionId);

        /// <summary>
        /// EncryptionScopesList (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes)
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes")]
        Task<EncryptionScopeListResult> EncryptionScopesListAsync([Path] string subscriptionId);
    }
}