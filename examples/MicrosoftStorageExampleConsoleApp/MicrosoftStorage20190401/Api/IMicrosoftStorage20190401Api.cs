using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnyOfTypes;
using RestEase;
using MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Api
{
    /// <summary>
    /// The Azure Storage Management API.
    /// </summary>
    public interface IMicrosoftStorage20190401Api
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
        /// <param name="expand">May be used to expand the properties within account's properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats.</param>
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
        /// StorageAccountsRevokeUserDelegationKeys (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/revokeUserDelegationKeys)
        /// </summary>
        /// <param name="accountName">The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.</param>
        /// <param name="resourceGroupName">The name of the resource group within the user's subscription. The name is case insensitive.</param>
        /// <param name="subscriptionId">The ID of the target subscription.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/revokeUserDelegationKeys?")]
        Task<object> StorageAccountsRevokeUserDelegationKeysAsync([Path] string accountName, [Path] string resourceGroupName, [Path] string subscriptionId);
    }
}