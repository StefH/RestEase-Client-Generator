using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnyOfTypes;
using RestEase;
using MicrosoftExampleConsoleApp.MicrosoftWebApps.Models;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Api
{
    /// <summary>
    /// MicrosoftWebApps
    /// </summary>
    public interface IMicrosoftWebAppsApi
    {
        /// <summary>
        /// Get all apps for a subscription.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Web/sites?api-version=2021-03-01")]
        Task<Response<AnyOf<WebAppCollection, DefaultErrorResponse>>> WebAppsListAsync([Path] string subscriptionId);

        /// <summary>
        /// Gets all web, mobile, and API apps in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="includeSlots">Specify true to include deployment slots in results. The default is false, which only gives you the production slot of all apps.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites?api-version=2021-03-01")]
        Task<Response<AnyOf<WebAppCollection, DefaultErrorResponse>>> WebAppsListByResourceGroupAsync([Path] string resourceGroupName, [Path] string subscriptionId, [Query] bool? includeSlots);

        /// <summary>
        /// Gets the details of a web, mobile, or API app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}?api-version=2021-03-01")]
        Task<Response<AnyOf<Site, object, DefaultErrorResponse>>> WebAppsGetAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a new web, mobile, or API app in an existing resource group, or updates an existing app.
        /// </summary>
        /// <param name="name">Unique name of the app to create or update. To create or update a deployment slot, use the {slot} parameter.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">A JSON representation of the app properties. See example.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Site, DefaultErrorResponse>>> WebAppsCreateOrUpdateAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] Site content);

        /// <summary>
        /// Deletes a web, mobile, or API app, or one of the deployment slots.
        /// </summary>
        /// <param name="name">Name of the app to delete.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="deleteMetrics">If true, web app metrics are also deleted.</param>
        /// <param name="deleteEmptyServerFarm">Specify false if you want to keep empty App Service plan. By default, empty App Service plan is deleted.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Query] bool? deleteMetrics, [Query] bool? deleteEmptyServerFarm);

        /// <summary>
        /// Creates a new web, mobile, or API app in an existing resource group, or updates an existing app.
        /// </summary>
        /// <param name="name">Unique name of the app to create or update. To create or update a deployment slot, use the {slot} parameter.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">ARM resource for a site.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Site, DefaultErrorResponse>>> WebAppsUpdateAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SitePatchResource content);

        /// <summary>
        /// Analyze a custom hostname.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="hostName">Custom hostname.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/analyzeCustomHostname?api-version=2021-03-01")]
        Task<Response<AnyOf<CustomHostnameAnalysisResult, DefaultErrorResponse>>> WebAppsAnalyzeCustomHostnameAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Query] string hostName);

        /// <summary>
        /// Applies the configuration settings from the target slot onto the current slot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Deployment slot parameters.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/applySlotConfig?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsApplySlotConfigToProductionAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] CsmSlotEntity content);

        /// <summary>
        /// Creates a backup of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Description of a backup which will be performed.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/backup?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<BackupItem, DefaultErrorResponse>>> WebAppsBackupAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] BackupRequest content);

        /// <summary>
        /// Gets existing backups of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/backups?api-version=2021-03-01")]
        Task<Response<AnyOf<BackupItemCollection, DefaultErrorResponse>>> WebAppsListBackupsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a backup of an app by its ID.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="backupId">ID of the backup.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/backups/{backupId}?api-version=2021-03-01")]
        Task<Response<AnyOf<BackupItem, DefaultErrorResponse>>> WebAppsGetBackupStatusAsync([Path] string name, [Path] string backupId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Deletes a backup of an app by its ID.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="backupId">ID of the backup.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/backups/{backupId}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteBackupAsync([Path] string name, [Path] string backupId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets status of a web app backup that may be in progress, including secrets associated with the backup, such as the Azure Storage SAS URL. Also can be used to update the SAS URL for the backup if a new URL is passed in the request body.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="backupId">ID of backup.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Description of a backup which will be performed.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/backups/{backupId}/list?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<BackupItem, DefaultErrorResponse>>> WebAppsListBackupStatusSecretsAsync([Path] string name, [Path] string backupId, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] BackupRequest content);

        /// <summary>
        /// Restores a specific backup to another app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="backupId">ID of the backup.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Description of a restore request.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/backups/{backupId}/restore?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsRestoreAsync([Path] string name, [Path] string backupId, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] RestoreRequest content);

        /// <summary>
        /// Returns whether Scm basic auth is allowed and whether Ftp is allowed for a given site.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies?api-version=2021-03-01")]
        Task<Response<AnyOf<PublishingCredentialsPoliciesCollection, DefaultErrorResponse>>> WebAppsListBasicPublishingCredentialsPoliciesAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Returns whether FTP is allowed on the site or not.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/ftp?api-version=2021-03-01")]
        Task<Response<AnyOf<CsmPublishingCredentialsPoliciesEntity, DefaultErrorResponse>>> WebAppsGetFtpAllowedAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates whether FTP is allowed on the site or not.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Publishing Credentials Policies parameters.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/ftp?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<CsmPublishingCredentialsPoliciesEntity, DefaultErrorResponse>>> WebAppsUpdateFtpAllowedAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] CsmPublishingCredentialsPoliciesEntity content);

        /// <summary>
        /// Returns whether Scm basic auth is allowed on the site or not.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/scm?api-version=2021-03-01")]
        Task<Response<AnyOf<CsmPublishingCredentialsPoliciesEntity, DefaultErrorResponse>>> WebAppsGetScmAllowedAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates whether user publishing credentials are allowed on the site or not.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Publishing Credentials Policies parameters.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/scm?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<CsmPublishingCredentialsPoliciesEntity, DefaultErrorResponse>>> WebAppsUpdateScmAllowedAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] CsmPublishingCredentialsPoliciesEntity content);

        /// <summary>
        /// List the configurations of an app
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteConfigResourceCollection, DefaultErrorResponse>>> WebAppsListConfigurationsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Replaces the application settings of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Application settings of the app.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/appsettings?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<StringDictionary, DefaultErrorResponse>>> WebAppsUpdateApplicationSettingsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] StringDictionary content);

        /// <summary>
        /// Gets the application settings of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/appsettings/list?api-version=2021-03-01")]
        Task<Response<AnyOf<StringDictionary, DefaultErrorResponse>>> WebAppsListApplicationSettingsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates the Authentication / Authorization settings associated with web app.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Configuration settings for the Azure App Service Authentication / Authorization feature.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettings?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SiteAuthSettings, DefaultErrorResponse>>> WebAppsUpdateAuthSettingsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SiteAuthSettings content);

        /// <summary>
        /// Gets the Authentication/Authorization settings of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettings/list?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteAuthSettings, DefaultErrorResponse>>> WebAppsGetAuthSettingsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets site's Authentication / Authorization settings for apps via the V2 format
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettingsV2?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteAuthSettingsV2, DefaultErrorResponse>>> WebAppsGetAuthSettingsV2WithoutSecretsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates site's Authentication / Authorization settings for apps via the V2 format
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Configuration settings for the Azure App Service Authentication / Authorization V2 feature.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettingsV2?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SiteAuthSettingsV2, DefaultErrorResponse>>> WebAppsUpdateAuthSettingsV2Async([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SiteAuthSettingsV2 content);

        /// <summary>
        /// Gets site's Authentication / Authorization settings for apps via the V2 format
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettingsV2/list?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteAuthSettingsV2, DefaultErrorResponse>>> WebAppsGetAuthSettingsV2Async([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates the Azure storage account configurations of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">AzureStorageInfo dictionary resource.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/azurestorageaccounts?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<AzureStoragePropertyDictionaryResource, DefaultErrorResponse>>> WebAppsUpdateAzureStorageAccountsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] AzureStoragePropertyDictionaryResource content);

        /// <summary>
        /// Gets the Azure storage account configurations of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/azurestorageaccounts/list?api-version=2021-03-01")]
        Task<Response<AnyOf<AzureStoragePropertyDictionaryResource, DefaultErrorResponse>>> WebAppsListAzureStorageAccountsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates the backup configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Description of a backup which will be performed.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/backup?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<BackupRequest, DefaultErrorResponse>>> WebAppsUpdateBackupConfigurationAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] BackupRequest content);

        /// <summary>
        /// Deletes the backup configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/backup?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteBackupConfigurationAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the backup configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/backup/list?api-version=2021-03-01")]
        Task<Response<AnyOf<BackupRequest, DefaultErrorResponse>>> WebAppsGetBackupConfigurationAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the config reference app settings and status of an app
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/configreferences/appsettings?api-version=2021-03-01")]
        Task<Response<AnyOf<ApiKVReferenceCollection, DefaultErrorResponse>>> WebAppsGetAppSettingsKeyVaultReferencesAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the config reference and status of an app
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="appSettingKey">App Setting key name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/configreferences/appsettings/{appSettingKey}?api-version=2021-03-01")]
        Task<Response<AnyOf<ApiKVReference, DefaultErrorResponse>>> WebAppsGetAppSettingKeyVaultReferenceAsync([Path] string name, [Path] string appSettingKey, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the config reference app settings and status of an app
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/configreferences/connectionstrings?api-version=2021-03-01")]
        Task<Response<AnyOf<ApiKVReferenceCollection, DefaultErrorResponse>>> WebAppsGetSiteConnectionStringKeyVaultReferencesAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the config reference and status of an app
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="connectionStringKey"></param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/configreferences/connectionstrings/{connectionStringKey}?api-version=2021-03-01")]
        Task<Response<AnyOf<ApiKVReference, DefaultErrorResponse>>> WebAppsGetSiteConnectionStringKeyVaultReferenceAsync([Path] string name, [Path] string connectionStringKey, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Replaces the connection strings of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">String dictionary resource.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/connectionstrings?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ConnectionStringDictionary, DefaultErrorResponse>>> WebAppsUpdateConnectionStringsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] ConnectionStringDictionary content);

        /// <summary>
        /// Gets the connection strings of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/connectionstrings/list?api-version=2021-03-01")]
        Task<Response<AnyOf<ConnectionStringDictionary, DefaultErrorResponse>>> WebAppsListConnectionStringsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the logging configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/logs?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteLogsConfig, DefaultErrorResponse>>> WebAppsGetDiagnosticLogsConfigurationAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates the logging configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Configuration of App Service site logs.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/logs?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SiteLogsConfig, DefaultErrorResponse>>> WebAppsUpdateDiagnosticLogsConfigAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SiteLogsConfig content);

        /// <summary>
        /// Replaces the metadata of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Edited metadata of the app or deployment slot. See example.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/metadata?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<StringDictionary, DefaultErrorResponse>>> WebAppsUpdateMetadataAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] StringDictionary content);

        /// <summary>
        /// Gets the metadata of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/metadata/list?api-version=2021-03-01")]
        Task<Response<AnyOf<StringDictionary, DefaultErrorResponse>>> WebAppsListMetadataAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the Git/FTP publishing credentials of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/publishingcredentials/list?api-version=2021-03-01")]
        Task<Response<AnyOf<User, DefaultErrorResponse>>> WebAppsListPublishingCredentialsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates the Push settings associated with web app.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Push settings associated with web app.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/pushsettings?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PushSettings, DefaultErrorResponse>>> WebAppsUpdateSitePushSettingsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] PushSettings content);

        /// <summary>
        /// Gets the Push settings associated with web app.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/pushsettings/list?api-version=2021-03-01")]
        Task<Response<AnyOf<PushSettings, DefaultErrorResponse>>> WebAppsListSitePushSettingsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the names of app settings and connection strings that stick to the slot (not swapped).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/slotConfigNames?api-version=2021-03-01")]
        Task<Response<AnyOf<SlotConfigNamesResource, DefaultErrorResponse>>> WebAppsListSlotConfigurationNamesAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates the names of application settings and connection string that remain with the slot during swap operation.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Slot Config names azure resource.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/slotConfigNames?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SlotConfigNamesResource, DefaultErrorResponse>>> WebAppsUpdateSlotConfigurationNamesAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SlotConfigNamesResource content);

        /// <summary>
        /// Gets the configuration of an app, such as platform version and bitness, default documents, virtual applications, Always On, etc.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/web?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteConfigResource, DefaultErrorResponse>>> WebAppsGetConfigurationAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates the configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Web app configuration ARM resource.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/web?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SiteConfigResource, DefaultErrorResponse>>> WebAppsCreateOrUpdateConfigurationAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SiteConfigResource content);

        /// <summary>
        /// Updates the configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Web app configuration ARM resource.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/web?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SiteConfigResource, DefaultErrorResponse>>> WebAppsUpdateConfigurationAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SiteConfigResource content);

        /// <summary>
        /// Gets a list of web app configuration snapshots identifiers. Each element of the list contains a timestamp and the ID of the snapshot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/web/snapshots?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteConfigurationSnapshotInfoCollection, DefaultErrorResponse>>> WebAppsListConfigurationSnapshotInfoAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a snapshot of the configuration of an app at a previous point in time.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="snapshotId">The ID of the snapshot to read.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/web/snapshots/{snapshotId}?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteConfigResource, DefaultErrorResponse>>> WebAppsGetConfigurationSnapshotAsync([Path] string name, [Path] string snapshotId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Reverts the configuration of an app to a previous snapshot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="snapshotId">The ID of the snapshot to read.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/web/snapshots/{snapshotId}/recover?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsRecoverSiteConfigurationSnapshotAsync([Path] string name, [Path] string snapshotId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the last lines of docker logs for the given site
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/containerlogs?api-version=2021-03-01")]
        Task<object> WebAppsGetWebSiteContainerLogsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the ZIP archived docker log files for the given site
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/containerlogs/zip/download?api-version=2021-03-01")]
        Task<object> WebAppsGetContainerLogsZipAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List continuous web jobs for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs?api-version=2021-03-01")]
        Task<Response<AnyOf<ContinuousWebJobCollection, DefaultErrorResponse>>> WebAppsListContinuousWebJobsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a continuous web job by its ID for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}?api-version=2021-03-01")]
        Task<Response<AnyOf<ContinuousWebJob, object, DefaultErrorResponse>>> WebAppsGetContinuousWebJobAsync([Path] string name, [Path] string webJobName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Delete a continuous web job by its ID for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteContinuousWebJobAsync([Path] string name, [Path] string webJobName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Start a continuous web job for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}/start?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsStartContinuousWebJobAsync([Path] string name, [Path] string webJobName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Stop a continuous web job for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}/stop?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsStopContinuousWebJobAsync([Path] string name, [Path] string webJobName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List deployments for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deployments?api-version=2021-03-01")]
        Task<Response<AnyOf<DeploymentCollection, DefaultErrorResponse>>> WebAppsListDeploymentsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get a deployment by its ID for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="id">Deployment ID.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deployments/{id}?api-version=2021-03-01")]
        Task<Response<AnyOf<Deployment, DefaultErrorResponse>>> WebAppsGetDeploymentAsync([Path] string name, [Path] string id, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Create a deployment for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="id">ID of an existing deployment.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">User credentials used for publishing activity.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deployments/{id}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Deployment, DefaultErrorResponse>>> WebAppsCreateDeploymentAsync([Path] string name, [Path] string id, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] Deployment content);

        /// <summary>
        /// Delete a deployment by its ID for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="id">Deployment ID.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deployments/{id}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteDeploymentAsync([Path] string name, [Path] string id, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List deployment log for specific deployment for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="id">The ID of a specific deployment. This is the value of the name property in the JSON response from "GET /api/sites/{siteName}/deployments".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deployments/{id}/log?api-version=2021-03-01")]
        Task<Response<AnyOf<Deployment, DefaultErrorResponse>>> WebAppsListDeploymentLogAsync([Path] string name, [Path] string id, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Discovers an existing app backup that can be restored from a blob in Azure storage. Use this to get information about the databases stored in a backup.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Description of a restore request.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/discoverbackup?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<RestoreRequest, DefaultErrorResponse>>> WebAppsDiscoverBackupAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] RestoreRequest content);

        /// <summary>
        /// Lists ownership identifiers for domain associated with web app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers?api-version=2021-03-01")]
        Task<Response<AnyOf<IdentifierCollection, DefaultErrorResponse>>> WebAppsListDomainOwnershipIdentifiersAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get domain ownership identifier for web app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="domainOwnershipIdentifierName">Name of domain ownership identifier.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}?api-version=2021-03-01")]
        Task<Response<AnyOf<Identifier, DefaultErrorResponse>>> WebAppsGetDomainOwnershipIdentifierAsync([Path] string name, [Path] string domainOwnershipIdentifierName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a domain ownership identifier for web app, or updates an existing ownership identifier.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="domainOwnershipIdentifierName">Name of domain ownership identifier.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">A JSON representation of the domain ownership properties.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Identifier, DefaultErrorResponse>>> WebAppsCreateOrUpdateDomainOwnershipIdentifierAsync([Path] string name, [Path] string domainOwnershipIdentifierName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] Identifier content);

        /// <summary>
        /// Deletes a domain ownership identifier for a web app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="domainOwnershipIdentifierName">Name of domain ownership identifier.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteDomainOwnershipIdentifierAsync([Path] string name, [Path] string domainOwnershipIdentifierName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a domain ownership identifier for web app, or updates an existing ownership identifier.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="domainOwnershipIdentifierName">Name of domain ownership identifier.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">A JSON representation of the domain ownership properties.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Identifier, DefaultErrorResponse>>> WebAppsUpdateDomainOwnershipIdentifierAsync([Path] string name, [Path] string domainOwnershipIdentifierName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] Identifier content);

        /// <summary>
        /// Get the status of the last MSDeploy operation.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/extensions/MSDeploy?api-version=2021-03-01")]
        Task<Response<AnyOf<MSDeployStatus, DefaultErrorResponse>>> WebAppsGetMSDeployStatusAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Invoke the MSDeploy web app extension.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">MSDeploy ARM PUT information</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/extensions/MSDeploy?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<MSDeployStatus, object, DefaultErrorResponse>>> WebAppsCreateMSDeployOperationAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] MSDeploy content);

        /// <summary>
        /// Get the MSDeploy Log for the last MSDeploy operation.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/extensions/MSDeploy/log?api-version=2021-03-01")]
        Task<Response<AnyOf<MSDeployLog, object, DefaultErrorResponse>>> WebAppsGetMSDeployLogAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Invoke onedeploy status API /api/deployments and gets the deployment status for the site
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/extensions/onedeploy?api-version=2021-03-01")]
        Task<Response<AnyOf<WebAppsGetOneDeployStatusResult, DefaultErrorResponse>>> WebAppsGetOneDeployStatusAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Invoke the OneDeploy publish web app extension.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/extensions/onedeploy?api-version=2021-03-01")]
        Task<Response<AnyOf<WebAppsCreateOneDeployOperationResult, DefaultErrorResponse>>> WebAppsCreateOneDeployOperationAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List the functions for a web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions?api-version=2021-03-01")]
        Task<Response<AnyOf<FunctionEnvelopeCollection, object, DefaultErrorResponse>>> WebAppsListFunctionsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Fetch a short lived token that can be exchanged for a master key.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions/admin/token?api-version=2021-03-01")]
        Task<Response<AnyOf<string, DefaultErrorResponse>>> WebAppsGetFunctionsAdminTokenAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get function information by its ID for web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="functionName">Function name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions/{functionName}?api-version=2021-03-01")]
        Task<Response<AnyOf<FunctionEnvelope, object, DefaultErrorResponse>>> WebAppsGetFunctionAsync([Path] string name, [Path] string functionName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Create function for web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="functionName">Function name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Function information.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions/{functionName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<FunctionEnvelope, DefaultErrorResponse>>> WebAppsCreateFunctionAsync([Path] string name, [Path] string functionName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] FunctionEnvelope content);

        /// <summary>
        /// Delete a function for web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="functionName">Function name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions/{functionName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteFunctionAsync([Path] string name, [Path] string functionName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Add or update a function secret.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="functionName">The name of the function.</param>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Function key info.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions/{functionName}/keys/{keyName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<KeyInfo, DefaultErrorResponse>>> WebAppsCreateOrUpdateFunctionSecretAsync([Path] string name, [Path] string functionName, [Path] string keyName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] KeyInfo content);

        /// <summary>
        /// Delete a function secret.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="functionName">The name of the function.</param>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions/{functionName}/keys/{keyName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteFunctionSecretAsync([Path] string name, [Path] string functionName, [Path] string keyName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get function keys for a function in a web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="functionName">Function name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions/{functionName}/listkeys?api-version=2021-03-01")]
        Task<Response<AnyOf<StringDictionary, DefaultErrorResponse>>> WebAppsListFunctionKeysAsync([Path] string name, [Path] string functionName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get function secrets for a function in a web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="functionName">Function name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions/{functionName}/listsecrets?api-version=2021-03-01")]
        Task<Response<AnyOf<FunctionSecrets, DefaultErrorResponse>>> WebAppsListFunctionSecretsAsync([Path] string name, [Path] string functionName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get host secrets for a function app.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/host/default/listkeys?api-version=2021-03-01")]
        Task<Response<AnyOf<HostKeys, DefaultErrorResponse>>> WebAppsListHostKeysAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// This is to allow calling via powershell and ARM template.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/host/default/listsyncstatus?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsListSyncStatusAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Syncs function trigger metadata to the management database
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/host/default/sync?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsSyncFunctionsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Add or update a host level secret.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="keyType">The type of host key.</param>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Function key info.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/host/default/{keyType}/{keyName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<KeyInfo, DefaultErrorResponse>>> WebAppsCreateOrUpdateHostSecretAsync([Path] string name, [Path] string keyType, [Path] string keyName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] KeyInfo content);

        /// <summary>
        /// Delete a host level secret.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="keyType">The type of host key.</param>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/host/default/{keyType}/{keyName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteHostSecretAsync([Path] string name, [Path] string keyType, [Path] string keyName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get hostname bindings for an app or a deployment slot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings?api-version=2021-03-01")]
        Task<Response<AnyOf<HostNameBindingCollection, DefaultErrorResponse>>> WebAppsListHostNameBindingsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get the named hostname binding for an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="hostName">Hostname in the hostname binding.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings/{hostName}?api-version=2021-03-01")]
        Task<Response<AnyOf<HostNameBinding, DefaultErrorResponse>>> WebAppsGetHostNameBindingAsync([Path] string name, [Path] string hostName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a hostname binding for an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="hostName">Hostname in the hostname binding.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">A hostname binding object.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings/{hostName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<HostNameBinding, DefaultErrorResponse>>> WebAppsCreateOrUpdateHostNameBindingAsync([Path] string name, [Path] string hostName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] HostNameBinding content);

        /// <summary>
        /// Deletes a hostname binding for an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="hostName">Hostname in the hostname binding.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings/{hostName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteHostNameBindingAsync([Path] string name, [Path] string hostName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Retrieves a specific Service Bus Hybrid Connection used by this Web App.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="namespaceName">The namespace for this hybrid connection.</param>
        /// <param name="relayName">The relay name for this hybrid connection.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}?api-version=2021-03-01")]
        Task<Response<AnyOf<HybridConnection, DefaultErrorResponse>>> WebAppsGetHybridConnectionAsync([Path] string name, [Path] string namespaceName, [Path] string relayName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a new Hybrid Connection using a Service Bus relay.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="namespaceName">The namespace for this hybrid connection.</param>
        /// <param name="relayName">The relay name for this hybrid connection.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">The details of the hybrid connection.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<HybridConnection, DefaultErrorResponse>>> WebAppsCreateOrUpdateHybridConnectionAsync([Path] string name, [Path] string namespaceName, [Path] string relayName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] HybridConnection content);

        /// <summary>
        /// Removes a Hybrid Connection from this site.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="namespaceName">The namespace for this hybrid connection.</param>
        /// <param name="relayName">The relay name for this hybrid connection.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteHybridConnectionAsync([Path] string name, [Path] string namespaceName, [Path] string relayName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a new Hybrid Connection using a Service Bus relay.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="namespaceName">The namespace for this hybrid connection.</param>
        /// <param name="relayName">The relay name for this hybrid connection.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">The details of the hybrid connection.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<HybridConnection, DefaultErrorResponse>>> WebAppsUpdateHybridConnectionAsync([Path] string name, [Path] string namespaceName, [Path] string relayName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] HybridConnection content);

        /// <summary>
        /// Retrieves all Service Bus Hybrid Connections used by this Web App.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionRelays?api-version=2021-03-01")]
        Task<Response<AnyOf<HybridConnection, DefaultErrorResponse>>> WebAppsListHybridConnectionsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets hybrid connections configured for an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection?api-version=2021-03-01")]
        Task<Response<AnyOf<RelayServiceConnectionEntity, DefaultErrorResponse>>> WebAppsListRelayServiceConnectionsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a hybrid connection configuration by its name.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="entityName">Name of the hybrid connection.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection/{entityName}?api-version=2021-03-01")]
        Task<Response<AnyOf<RelayServiceConnectionEntity, DefaultErrorResponse>>> WebAppsGetRelayServiceConnectionAsync([Path] string name, [Path] string entityName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a new hybrid connection configuration (PUT), or updates an existing one (PATCH).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="entityName">Name of the hybrid connection configuration.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Hybrid Connection for an App Service app.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection/{entityName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<RelayServiceConnectionEntity, DefaultErrorResponse>>> WebAppsCreateOrUpdateRelayServiceConnectionAsync([Path] string name, [Path] string entityName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] RelayServiceConnectionEntity content);

        /// <summary>
        /// Deletes a relay service connection by its name.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="entityName">Name of the hybrid connection configuration.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection/{entityName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteRelayServiceConnectionAsync([Path] string name, [Path] string entityName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a new hybrid connection configuration (PUT), or updates an existing one (PATCH).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="entityName">Name of the hybrid connection configuration.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Hybrid Connection for an App Service app.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection/{entityName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<RelayServiceConnectionEntity, DefaultErrorResponse>>> WebAppsUpdateRelayServiceConnectionAsync([Path] string name, [Path] string entityName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] RelayServiceConnectionEntity content);

        /// <summary>
        /// Gets all scale-out instances of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances?api-version=2021-03-01")]
        Task<Response<AnyOf<WebAppInstanceStatusCollection, DefaultErrorResponse>>> WebAppsListInstanceIdentifiersAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets all scale-out instances of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="instanceId"></param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}?api-version=2021-03-01")]
        Task<Response<AnyOf<WebSiteInstanceStatus, DefaultErrorResponse>>> WebAppsGetInstanceInfoAsync([Path] string name, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get the status of the last MSDeploy operation.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="instanceId">ID of web app instance.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/extensions/MSDeploy?api-version=2021-03-01")]
        Task<Response<AnyOf<MSDeployStatus, DefaultErrorResponse>>> WebAppsGetInstanceMsDeployStatusAsync([Path] string name, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Invoke the MSDeploy web app extension.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="instanceId">ID of web app instance.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">MSDeploy ARM PUT information</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/extensions/MSDeploy?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<MSDeployStatus, object, DefaultErrorResponse>>> WebAppsCreateInstanceMSDeployOperationAsync([Path] string name, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] MSDeploy content);

        /// <summary>
        /// Get the MSDeploy Log for the last MSDeploy operation.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="instanceId">ID of web app instance.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/extensions/MSDeploy/log?api-version=2021-03-01")]
        Task<Response<AnyOf<MSDeployLog, object, DefaultErrorResponse>>> WebAppsGetInstanceMSDeployLogAsync([Path] string name, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get list of processes for a web site, or a deployment slot, or for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="instanceId">ID of a specific scaled-out instance. This is the value of the name property in the JSON response from "GET api/sites/{siteName}/instances".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessInfoCollection, object, DefaultErrorResponse>>> WebAppsListInstanceProcessesAsync([Path] string name, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get process information by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="instanceId">ID of a specific scaled-out instance. This is the value of the name property in the JSON response from "GET api/sites/{siteName}/instances".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes/{processId}?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessInfo, object, DefaultErrorResponse>>> WebAppsGetInstanceProcessAsync([Path] string name, [Path] string processId, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Terminate a process by its ID for a web site, or a deployment slot, or specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="instanceId">ID of a specific scaled-out instance. This is the value of the name property in the JSON response from "GET api/sites/{siteName}/instances".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes/{processId}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteInstanceProcessAsync([Path] string name, [Path] string processId, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get a memory dump of a process by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="instanceId">ID of a specific scaled-out instance. This is the value of the name property in the JSON response from "GET api/sites/{siteName}/instances".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes/{processId}/dump?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsGetInstanceProcessDumpAsync([Path] string name, [Path] string processId, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List module information for a process by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="instanceId">ID of a specific scaled-out instance. This is the value of the name property in the JSON response from "GET api/sites/{siteName}/instances".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes/{processId}/modules?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessModuleInfoCollection, object, DefaultErrorResponse>>> WebAppsListInstanceProcessModulesAsync([Path] string name, [Path] string processId, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get process information by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="baseAddress">Module base address.</param>
        /// <param name="instanceId">ID of a specific scaled-out instance. This is the value of the name property in the JSON response from "GET api/sites/{siteName}/instances".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes/{processId}/modules/{baseAddress}?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessModuleInfo, object, DefaultErrorResponse>>> WebAppsGetInstanceProcessModuleAsync([Path] string name, [Path] string processId, [Path] string baseAddress, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List the threads in a process by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="instanceId">ID of a specific scaled-out instance. This is the value of the name property in the JSON response from "GET api/sites/{siteName}/instances".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes/{processId}/threads?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessThreadInfoCollection, object, DefaultErrorResponse>>> WebAppsListInstanceProcessThreadsAsync([Path] string name, [Path] string processId, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Shows whether an app can be cloned to another resource group or subscription.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/iscloneable?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteCloneability, DefaultErrorResponse>>> WebAppsIsCloneableAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets existing backups of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/listbackups?api-version=2021-03-01")]
        Task<Response<AnyOf<BackupItemCollection, DefaultErrorResponse>>> WebAppsListSiteBackupsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// This is to allow calling via powershell and ARM template.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/listsyncfunctiontriggerstatus?api-version=2021-03-01")]
        Task<Response<AnyOf<FunctionSecrets, DefaultErrorResponse>>> WebAppsListSyncFunctionTriggersAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Restores a web app.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Options for app content migration.</param>
        /// <param name="subscriptionName">Azure subscription.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/migrate?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<StorageMigrationResponse, DefaultErrorResponse>>> WebAppsMigrateStorageAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] StorageMigrationOptions content, [Query] string subscriptionName);

        /// <summary>
        /// Migrates a local (in-app) MySql database to a remote MySql database.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">MySQL migration request.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/migratemysql?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Models.Operation, DefaultErrorResponse>>> WebAppsMigrateMySqlAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] MigrateMySqlRequest content);

        /// <summary>
        /// Returns the status of MySql in app migration, if one is active, and whether or not MySql in app is enabled
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/migratemysql/status?api-version=2021-03-01")]
        Task<Response<AnyOf<MigrateMySqlStatus, DefaultErrorResponse>>> WebAppsGetMigrateMySqlStatusAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a Swift Virtual Network connection.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkConfig/virtualNetwork?api-version=2021-03-01")]
        Task<Response<AnyOf<SwiftVirtualNetwork, DefaultErrorResponse>>> WebAppsGetSwiftVirtualNetworkConnectionAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Integrates this Web App with a Virtual Network. This requires that 1) "swiftSupported" is true when doing a GET against this resource, and 2) that the target Subnet has already been delegated, and is notin use by another App Service Plan other than the one this App is in.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Swift Virtual Network Contract. This is used to enable the new Swift way of doing virtual network integration.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkConfig/virtualNetwork?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SwiftVirtualNetwork, DefaultErrorResponse>>> WebAppsCreateOrUpdateSwiftVirtualNetworkConnectionWithCheckAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SwiftVirtualNetwork content);

        /// <summary>
        /// Deletes a Swift Virtual Network connection from an app (or deployment slot).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkConfig/virtualNetwork?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteSwiftVirtualNetworkAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Integrates this Web App with a Virtual Network. This requires that 1) "swiftSupported" is true when doing a GET against this resource, and 2) that the target Subnet has already been delegated, and is notin use by another App Service Plan other than the one this App is in.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Swift Virtual Network Contract. This is used to enable the new Swift way of doing virtual network integration.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkConfig/virtualNetwork?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SwiftVirtualNetwork, DefaultErrorResponse>>> WebAppsUpdateSwiftVirtualNetworkConnectionWithCheckAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SwiftVirtualNetwork content);

        /// <summary>
        /// Gets all network features used by the app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="view">The type of view. Only "summary" is supported at this time.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkFeatures/{view}?api-version=2021-03-01")]
        Task<Response<AnyOf<NetworkFeatures, object, DefaultErrorResponse>>> WebAppsListNetworkFeaturesAsync([Path] string name, [Path] string view, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a named operation for a network trace capturing (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="operationId">GUID of the operation.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/operationresults/{operationId}?api-version=2021-03-01")]
        Task<Response<AnyOf<NetworkTrace[], DefaultErrorResponse>>> WebAppsGetNetworkTraceOperationAsync([Path] string name, [Path] string operationId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Start capturing network packets for the site (To be deprecated).
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="durationInSeconds">The duration to keep capturing in seconds.</param>
        /// <param name="maxFrameLength">The maximum frame length in bytes (Optional).</param>
        /// <param name="sasUrl">The Blob URL to store capture file.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/start?api-version=2021-03-01")]
        Task<Response<AnyOf<string, DefaultErrorResponse>>> WebAppsStartWebSiteNetworkTraceAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Query] int? durationInSeconds, [Query] int? maxFrameLength, [Query] string sasUrl);

        /// <summary>
        /// Start capturing network packets for the site.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="durationInSeconds">The duration to keep capturing in seconds.</param>
        /// <param name="maxFrameLength">The maximum frame length in bytes (Optional).</param>
        /// <param name="sasUrl">The Blob URL to store capture file.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/startOperation?api-version=2021-03-01")]
        Task<Response<AnyOf<NetworkTrace[], DefaultErrorResponse>>> WebAppsStartWebSiteNetworkTraceOperationAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Query] int? durationInSeconds, [Query] int? maxFrameLength, [Query] string sasUrl);

        /// <summary>
        /// Stop ongoing capturing network packets for the site.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/stop?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsStopWebSiteNetworkTraceAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a named operation for a network trace capturing (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="operationId">GUID of the operation.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/{operationId}?api-version=2021-03-01")]
        Task<Response<AnyOf<NetworkTrace[], DefaultErrorResponse>>> WebAppsGetNetworkTracesAsync([Path] string name, [Path] string operationId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a named operation for a network trace capturing (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="operationId">GUID of the operation.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTraces/current/operationresults/{operationId}?api-version=2021-03-01")]
        Task<Response<AnyOf<NetworkTrace[], DefaultErrorResponse>>> WebAppsGetNetworkTraceOperationV2Async([Path] string name, [Path] string operationId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a named operation for a network trace capturing (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="operationId">GUID of the operation.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTraces/{operationId}?api-version=2021-03-01")]
        Task<Response<AnyOf<NetworkTrace[], DefaultErrorResponse>>> WebAppsGetNetworkTracesV2Async([Path] string name, [Path] string operationId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Generates a new publishing password for an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/newpassword?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsGenerateNewSitePublishingPasswordAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets perfmon counters for web app.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="filter">Return only usages/metrics specified in the filter. Filter conforms to odata syntax. Example: $filter=(startTime eq 2014-01-01T00:00:00Z and endTime eq 2014-12-31T23:59:59Z and timeGrain eq duration'[Hour|Minute|Day]'.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/perfcounters?api-version=2021-03-01")]
        Task<Response<AnyOf<PerfMonCounterCollection, DefaultErrorResponse>>> WebAppsListPerfMonCountersAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Query(Name = "$filter")] string filter);

        /// <summary>
        /// Gets web app's event logs.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/phplogging?api-version=2021-03-01")]
        Task<Response<AnyOf<SitePhpErrorLogFlag, DefaultErrorResponse>>> WebAppsGetSitePhpErrorLogFlagAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the premier add-ons of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/premieraddons?api-version=2021-03-01")]
        Task<Response<AnyOf<PremierAddOn, DefaultErrorResponse>>> WebAppsListPremierAddOnsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a named add-on of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="premierAddOnName">Add-on name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/premieraddons/{premierAddOnName}?api-version=2021-03-01")]
        Task<Response<AnyOf<PremierAddOn, DefaultErrorResponse>>> WebAppsGetPremierAddOnAsync([Path] string name, [Path] string premierAddOnName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates a named add-on of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="premierAddOnName">Add-on name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Premier add-on.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/premieraddons/{premierAddOnName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PremierAddOn, DefaultErrorResponse>>> WebAppsAddPremierAddOnAsync([Path] string name, [Path] string premierAddOnName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] PremierAddOn content);

        /// <summary>
        /// Delete a premier add-on from an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="premierAddOnName">Add-on name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/premieraddons/{premierAddOnName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeletePremierAddOnAsync([Path] string name, [Path] string premierAddOnName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates a named add-on of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="premierAddOnName">Add-on name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">ARM resource for a PremierAddOn.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/premieraddons/{premierAddOnName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PremierAddOn, DefaultErrorResponse>>> WebAppsUpdatePremierAddOnAsync([Path] string name, [Path] string premierAddOnName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] PremierAddOnPatchResource content);

        /// <summary>
        /// Gets data around private site access enablement and authorized Virtual Networks that can access the site.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateAccess/virtualNetworks?api-version=2021-03-01")]
        Task<Response<AnyOf<PrivateAccess, DefaultErrorResponse>>> WebAppsGetPrivateAccessAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Sets data around private site access enablement and authorized Virtual Networks that can access the site.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Description of the parameters of Private Access for a Web Site.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateAccess/virtualNetworks?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PrivateAccess, DefaultErrorResponse>>> WebAppsPutPrivateAccessVnetAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] PrivateAccess content);

        /// <summary>
        /// Gets the list of private endpoint connections associated with a site
        /// </summary>
        /// <param name="name">Name of the site.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateEndpointConnections?api-version=2021-03-01")]
        Task<Response<AnyOf<PrivateEndpointConnectionCollection, DefaultErrorResponse>>> WebAppsGetPrivateEndpointConnectionListAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a private endpoint connection
        /// </summary>
        /// <param name="name">Name of the site.</param>
        /// <param name="privateEndpointConnectionName">Name of the private endpoint connection.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateEndpointConnections/{privateEndpointConnectionName}?api-version=2021-03-01")]
        Task<Response<AnyOf<RemotePrivateEndpointConnectionARMResource, DefaultErrorResponse>>> WebAppsGetPrivateEndpointConnectionAsync([Path] string name, [Path] string privateEndpointConnectionName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Approves or rejects a private endpoint connection
        /// </summary>
        /// <param name="name">Name of the site.</param>
        /// <param name="privateEndpointConnectionName"></param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content"></param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateEndpointConnections/{privateEndpointConnectionName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<RemotePrivateEndpointConnectionARMResource, DefaultErrorResponse>>> WebAppsApproveOrRejectPrivateEndpointConnectionAsync([Path] string name, [Path] string privateEndpointConnectionName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] PrivateLinkConnectionApprovalRequestResource content);

        /// <summary>
        /// Deletes a private endpoint connection
        /// </summary>
        /// <param name="name">Name of the site.</param>
        /// <param name="privateEndpointConnectionName"></param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateEndpointConnections/{privateEndpointConnectionName}?api-version=2021-03-01")]
        Task<Response<AnyOf<WebAppsDeletePrivateEndpointConnectionResult, DefaultErrorResponse>>> WebAppsDeletePrivateEndpointConnectionAsync([Path] string name, [Path] string privateEndpointConnectionName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the private link resources
        /// </summary>
        /// <param name="name">Name of the site.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateLinkResources?api-version=2021-03-01")]
        Task<Response<AnyOf<PrivateLinkResourcesWrapper, DefaultErrorResponse>>> WebAppsGetPrivateLinkResourcesAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get list of processes for a web site, or a deployment slot, or for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/processes?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessInfoCollection, object, DefaultErrorResponse>>> WebAppsListProcessesAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get process information by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/processes/{processId}?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessInfo, object, DefaultErrorResponse>>> WebAppsGetProcessAsync([Path] string name, [Path] string processId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Terminate a process by its ID for a web site, or a deployment slot, or specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/processes/{processId}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteProcessAsync([Path] string name, [Path] string processId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get a memory dump of a process by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/processes/{processId}/dump?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsGetProcessDumpAsync([Path] string name, [Path] string processId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List module information for a process by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/processes/{processId}/modules?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessModuleInfoCollection, object, DefaultErrorResponse>>> WebAppsListProcessModulesAsync([Path] string name, [Path] string processId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get process information by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="baseAddress">Module base address.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/processes/{processId}/modules/{baseAddress}?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessModuleInfo, object, DefaultErrorResponse>>> WebAppsGetProcessModuleAsync([Path] string name, [Path] string processId, [Path] string baseAddress, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List the threads in a process by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/processes/{processId}/threads?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessThreadInfoCollection, object, DefaultErrorResponse>>> WebAppsListProcessThreadsAsync([Path] string name, [Path] string processId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get public certificates for an app or a deployment slot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/publicCertificates?api-version=2021-03-01")]
        Task<Response<AnyOf<PublicCertificateCollection, DefaultErrorResponse>>> WebAppsListPublicCertificatesAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get the named public certificate for an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="publicCertificateName">Public certificate name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/publicCertificates/{publicCertificateName}?api-version=2021-03-01")]
        Task<Response<AnyOf<PublicCertificate, DefaultErrorResponse>>> WebAppsGetPublicCertificateAsync([Path] string name, [Path] string publicCertificateName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a hostname binding for an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="publicCertificateName">Public certificate name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Public certificate object</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/publicCertificates/{publicCertificateName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PublicCertificate, DefaultErrorResponse>>> WebAppsCreateOrUpdatePublicCertificateAsync([Path] string name, [Path] string publicCertificateName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] PublicCertificate content);

        /// <summary>
        /// Deletes a hostname binding for an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="publicCertificateName">Public certificate name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/publicCertificates/{publicCertificateName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeletePublicCertificateAsync([Path] string name, [Path] string publicCertificateName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the publishing profile for an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Publishing options for requested profile.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/publishxml?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<object> WebAppsListPublishingProfileXmlWithSecretsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] CsmPublishingProfileOptions content);

        /// <summary>
        /// Resets the configuration settings of the current slot if they were previously modified by calling the API with POST.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/resetSlotConfig?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsResetProductionSlotConfigAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Restarts an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="softRestart">Specify true to apply the configuration settings and restarts the app only if necessary. By default, the API always restarts and reprovisions the app.</param>
        /// <param name="synchronous">Specify true to block until the app is restarted. By default, it is set to false, and the API responds immediately (asynchronous).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/restart?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsRestartAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Query] bool? softRestart, [Query] bool? synchronous);

        /// <summary>
        /// Restores an app from a backup blob in Azure Storage.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Description of a restore request.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/restoreFromBackupBlob?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsRestoreFromBackupBlobAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] RestoreRequest content);

        /// <summary>
        /// Restores a deleted web app to this web app.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Details about restoring a deleted app.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/restoreFromDeletedApp?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsRestoreFromDeletedAppAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] DeletedAppRestoreRequest content);

        /// <summary>
        /// Restores a web app from a snapshot.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Details about app recovery operation.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/restoreSnapshot?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsRestoreSnapshotAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SnapshotRestoreRequest content);

        /// <summary>
        /// Get list of siteextensions for a web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/siteextensions?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteExtensionInfoCollection, object, DefaultErrorResponse>>> WebAppsListSiteExtensionsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get site extension information by its ID for a web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="siteExtensionId">Site extension name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/siteextensions/{siteExtensionId}?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteExtensionInfo, object, DefaultErrorResponse>>> WebAppsGetSiteExtensionAsync([Path] string name, [Path] string siteExtensionId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Install site extension on a web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="siteExtensionId">Site extension name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/siteextensions/{siteExtensionId}?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteExtensionInfo, object, DefaultErrorResponse>>> WebAppsInstallSiteExtensionAsync([Path] string name, [Path] string siteExtensionId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Remove a site extension from a web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="siteExtensionId">Site extension name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/siteextensions/{siteExtensionId}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteSiteExtensionAsync([Path] string name, [Path] string siteExtensionId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets an app's deployment slots.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots?api-version=2021-03-01")]
        Task<Response<AnyOf<WebAppCollection, DefaultErrorResponse>>> WebAppsListSlotsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the details of a web, mobile, or API app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. By default, this API returns the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}?api-version=2021-03-01")]
        Task<Response<AnyOf<Site, object, DefaultErrorResponse>>> WebAppsGetSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a new web, mobile, or API app in an existing resource group, or updates an existing app.
        /// </summary>
        /// <param name="name">Unique name of the app to create or update. To create or update a deployment slot, use the {slot} parameter.</param>
        /// <param name="slot">Name of the deployment slot to create or update. By default, this API attempts to create or modify the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">A JSON representation of the app properties. See example.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Site, DefaultErrorResponse>>> WebAppsCreateOrUpdateSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] Site content);

        /// <summary>
        /// Deletes a web, mobile, or API app, or one of the deployment slots.
        /// </summary>
        /// <param name="name">Name of the app to delete.</param>
        /// <param name="slot">Name of the deployment slot to delete. By default, the API deletes the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="deleteMetrics">If true, web app metrics are also deleted.</param>
        /// <param name="deleteEmptyServerFarm">Specify false if you want to keep empty App Service plan. By default, empty App Service plan is deleted.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Query] bool? deleteMetrics, [Query] bool? deleteEmptyServerFarm);

        /// <summary>
        /// Creates a new web, mobile, or API app in an existing resource group, or updates an existing app.
        /// </summary>
        /// <param name="name">Unique name of the app to create or update. To create or update a deployment slot, use the {slot} parameter.</param>
        /// <param name="slot">Name of the deployment slot to create or update. By default, this API attempts to create or modify the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">ARM resource for a site.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Site, DefaultErrorResponse>>> WebAppsUpdateSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SitePatchResource content);

        /// <summary>
        /// Analyze a custom hostname.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="hostName">Custom hostname.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/analyzeCustomHostname?api-version=2021-03-01")]
        Task<Response<AnyOf<CustomHostnameAnalysisResult, DefaultErrorResponse>>> WebAppsAnalyzeCustomHostnameSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Query] string hostName);

        /// <summary>
        /// Applies the configuration settings from the target slot onto the current slot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the source slot. If a slot is not specified, the production slot is used as the source slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Deployment slot parameters.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/applySlotConfig?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsApplySlotConfigurationSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] CsmSlotEntity content);

        /// <summary>
        /// Creates a backup of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will create a backup for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Description of a backup which will be performed.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/backup?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<BackupItem, DefaultErrorResponse>>> WebAppsBackupSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] BackupRequest content);

        /// <summary>
        /// Gets existing backups of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get backups of the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/backups?api-version=2021-03-01")]
        Task<Response<AnyOf<BackupItemCollection, DefaultErrorResponse>>> WebAppsListBackupsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a backup of an app by its ID.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="backupId">ID of the backup.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get a backup of the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/backups/{backupId}?api-version=2021-03-01")]
        Task<Response<AnyOf<BackupItem, DefaultErrorResponse>>> WebAppsGetBackupStatusSlotAsync([Path] string name, [Path] string backupId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Deletes a backup of an app by its ID.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="backupId">ID of the backup.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will delete a backup of the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/backups/{backupId}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteBackupSlotAsync([Path] string name, [Path] string backupId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets status of a web app backup that may be in progress, including secrets associated with the backup, such as the Azure Storage SAS URL. Also can be used to update the SAS URL for the backup if a new URL is passed in the request body.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="backupId">ID of backup.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Description of a backup which will be performed.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/backups/{backupId}/list?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<BackupItem, DefaultErrorResponse>>> WebAppsListBackupStatusSecretsSlotAsync([Path] string name, [Path] string backupId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] BackupRequest content);

        /// <summary>
        /// Restores a specific backup to another app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="backupId">ID of the backup.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will restore a backup of the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Description of a restore request.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/backups/{backupId}/restore?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsRestoreSlotAsync([Path] string name, [Path] string backupId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] RestoreRequest content);

        /// <summary>
        /// Returns whether Scm basic auth is allowed and whether Ftp is allowed for a given site.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot"></param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies?api-version=2021-03-01")]
        Task<Response<AnyOf<PublishingCredentialsPoliciesCollection, DefaultErrorResponse>>> WebAppsListBasicPublishingCredentialsPoliciesSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Returns whether FTP is allowed on the site or not.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot"></param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/ftp?api-version=2021-03-01")]
        Task<Response<AnyOf<CsmPublishingCredentialsPoliciesEntity, DefaultErrorResponse>>> WebAppsGetFtpAllowedSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates whether FTP is allowed on the site or not.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot"></param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Publishing Credentials Policies parameters.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/ftp?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<CsmPublishingCredentialsPoliciesEntity, DefaultErrorResponse>>> WebAppsUpdateFtpAllowedSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] CsmPublishingCredentialsPoliciesEntity content);

        /// <summary>
        /// Returns whether Scm basic auth is allowed on the site or not.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot"></param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/scm?api-version=2021-03-01")]
        Task<Response<AnyOf<CsmPublishingCredentialsPoliciesEntity, DefaultErrorResponse>>> WebAppsGetScmAllowedSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates whether user publishing credentials are allowed on the site or not.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot"></param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Publishing Credentials Policies parameters.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/scm?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<CsmPublishingCredentialsPoliciesEntity, DefaultErrorResponse>>> WebAppsUpdateScmAllowedSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] CsmPublishingCredentialsPoliciesEntity content);

        /// <summary>
        /// List the configurations of an app
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will return configuration for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteConfigResourceCollection, DefaultErrorResponse>>> WebAppsListConfigurationsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Replaces the application settings of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will update the application settings for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Application settings of the app.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/appsettings?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<StringDictionary, DefaultErrorResponse>>> WebAppsUpdateApplicationSettingsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] StringDictionary content);

        /// <summary>
        /// Gets the application settings of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get the application settings for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/appsettings/list?api-version=2021-03-01")]
        Task<Response<AnyOf<StringDictionary, DefaultErrorResponse>>> WebAppsListApplicationSettingsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates the Authentication / Authorization settings associated with web app.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Configuration settings for the Azure App Service Authentication / Authorization feature.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/authsettings?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SiteAuthSettings, DefaultErrorResponse>>> WebAppsUpdateAuthSettingsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SiteAuthSettings content);

        /// <summary>
        /// Gets the Authentication/Authorization settings of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get the settings for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/authsettings/list?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteAuthSettings, DefaultErrorResponse>>> WebAppsGetAuthSettingsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates site's Authentication / Authorization settings for apps via the V2 format
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Configuration settings for the Azure App Service Authentication / Authorization V2 feature.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/authsettingsV2?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SiteAuthSettingsV2, DefaultErrorResponse>>> WebAppsUpdateAuthSettingsV2SlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SiteAuthSettingsV2 content);

        /// <summary>
        /// Gets site's Authentication / Authorization settings for apps via the V2 format
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get the settings for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/authsettingsV2/list?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteAuthSettingsV2, DefaultErrorResponse>>> WebAppsGetAuthSettingsV2SlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates the Azure storage account configurations of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will update the Azure storage account configurations for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">AzureStorageInfo dictionary resource.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/azurestorageaccounts?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<AzureStoragePropertyDictionaryResource, DefaultErrorResponse>>> WebAppsUpdateAzureStorageAccountsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] AzureStoragePropertyDictionaryResource content);

        /// <summary>
        /// Gets the Azure storage account configurations of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will update the Azure storage account configurations for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/azurestorageaccounts/list?api-version=2021-03-01")]
        Task<Response<AnyOf<AzureStoragePropertyDictionaryResource, DefaultErrorResponse>>> WebAppsListAzureStorageAccountsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates the backup configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will update the backup configuration for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Description of a backup which will be performed.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/backup?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<BackupRequest, DefaultErrorResponse>>> WebAppsUpdateBackupConfigurationSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] BackupRequest content);

        /// <summary>
        /// Deletes the backup configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will delete the backup configuration for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/backup?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteBackupConfigurationSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the backup configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get the backup configuration for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/backup/list?api-version=2021-03-01")]
        Task<Response<AnyOf<BackupRequest, DefaultErrorResponse>>> WebAppsGetBackupConfigurationSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the config reference app settings and status of an app
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot"></param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/appsettings?api-version=2021-03-01")]
        Task<Response<AnyOf<ApiKVReferenceCollection, DefaultErrorResponse>>> WebAppsGetAppSettingsKeyVaultReferencesSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the config reference and status of an app
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="appSettingKey">App Setting key name.</param>
        /// <param name="slot"></param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/appsettings/{appSettingKey}?api-version=2021-03-01")]
        Task<Response<AnyOf<ApiKVReference, DefaultErrorResponse>>> WebAppsGetAppSettingKeyVaultReferenceSlotAsync([Path] string name, [Path] string appSettingKey, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the config reference app settings and status of an app
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot"></param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/connectionstrings?api-version=2021-03-01")]
        Task<Response<AnyOf<ApiKVReferenceCollection, DefaultErrorResponse>>> WebAppsGetSiteConnectionStringKeyVaultReferencesSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the config reference and status of an app
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="connectionStringKey"></param>
        /// <param name="slot"></param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/connectionstrings/{connectionStringKey}?api-version=2021-03-01")]
        Task<Response<AnyOf<ApiKVReference, DefaultErrorResponse>>> WebAppsGetSiteConnectionStringKeyVaultReferenceSlotAsync([Path] string name, [Path] string connectionStringKey, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Replaces the connection strings of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will update the connection settings for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">String dictionary resource.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/connectionstrings?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ConnectionStringDictionary, DefaultErrorResponse>>> WebAppsUpdateConnectionStringsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] ConnectionStringDictionary content);

        /// <summary>
        /// Gets the connection strings of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get the connection settings for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/connectionstrings/list?api-version=2021-03-01")]
        Task<Response<AnyOf<ConnectionStringDictionary, DefaultErrorResponse>>> WebAppsListConnectionStringsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the logging configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get the logging configuration for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/logs?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteLogsConfig, DefaultErrorResponse>>> WebAppsGetDiagnosticLogsConfigurationSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates the logging configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will update the logging configuration for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Configuration of App Service site logs.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/logs?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SiteLogsConfig, DefaultErrorResponse>>> WebAppsUpdateDiagnosticLogsConfigSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SiteLogsConfig content);

        /// <summary>
        /// Replaces the metadata of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will update the metadata for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Edited metadata of the app or deployment slot. See example.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/metadata?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<StringDictionary, DefaultErrorResponse>>> WebAppsUpdateMetadataSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] StringDictionary content);

        /// <summary>
        /// Gets the metadata of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get the metadata for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/metadata/list?api-version=2021-03-01")]
        Task<Response<AnyOf<StringDictionary, DefaultErrorResponse>>> WebAppsListMetadataSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the Git/FTP publishing credentials of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get the publishing credentials for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/publishingcredentials/list?api-version=2021-03-01")]
        Task<Response<AnyOf<User, DefaultErrorResponse>>> WebAppsListPublishingCredentialsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates the Push settings associated with web app.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Push settings associated with web app.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/pushsettings?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PushSettings, DefaultErrorResponse>>> WebAppsUpdateSitePushSettingsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] PushSettings content);

        /// <summary>
        /// Gets the Push settings associated with web app.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/pushsettings/list?api-version=2021-03-01")]
        Task<Response<AnyOf<PushSettings, DefaultErrorResponse>>> WebAppsListSitePushSettingsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the configuration of an app, such as platform version and bitness, default documents, virtual applications, Always On, etc.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will return configuration for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteConfigResource, DefaultErrorResponse>>> WebAppsGetConfigurationSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates the configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will update configuration for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Web app configuration ARM resource.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SiteConfigResource, DefaultErrorResponse>>> WebAppsCreateOrUpdateConfigurationSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SiteConfigResource content);

        /// <summary>
        /// Updates the configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will update configuration for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Web app configuration ARM resource.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SiteConfigResource, DefaultErrorResponse>>> WebAppsUpdateConfigurationSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SiteConfigResource content);

        /// <summary>
        /// Gets a list of web app configuration snapshots identifiers. Each element of the list contains a timestamp and the ID of the snapshot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will return configuration for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web/snapshots?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteConfigurationSnapshotInfoCollection, DefaultErrorResponse>>> WebAppsListConfigurationSnapshotInfoSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a snapshot of the configuration of an app at a previous point in time.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="snapshotId">The ID of the snapshot to read.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will return configuration for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web/snapshots/{snapshotId}?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteConfigResource, DefaultErrorResponse>>> WebAppsGetConfigurationSnapshotSlotAsync([Path] string name, [Path] string snapshotId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Reverts the configuration of an app to a previous snapshot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="snapshotId">The ID of the snapshot to read.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will return configuration for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web/snapshots/{snapshotId}/recover?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsRecoverSiteConfigurationSnapshotSlotAsync([Path] string name, [Path] string snapshotId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the last lines of docker logs for the given site
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/containerlogs?api-version=2021-03-01")]
        Task<object> WebAppsGetWebSiteContainerLogsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the ZIP archived docker log files for the given site
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/containerlogs/zip/download?api-version=2021-03-01")]
        Task<object> WebAppsGetContainerLogsZipSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List continuous web jobs for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API deletes a deployment for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs?api-version=2021-03-01")]
        Task<Response<AnyOf<ContinuousWebJobCollection, DefaultErrorResponse>>> WebAppsListContinuousWebJobsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a continuous web job by its ID for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API deletes a deployment for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}?api-version=2021-03-01")]
        Task<Response<AnyOf<ContinuousWebJob, object, DefaultErrorResponse>>> WebAppsGetContinuousWebJobSlotAsync([Path] string name, [Path] string webJobName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Delete a continuous web job by its ID for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API deletes a deployment for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteContinuousWebJobSlotAsync([Path] string name, [Path] string webJobName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Start a continuous web job for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API deletes a deployment for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}/start?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsStartContinuousWebJobSlotAsync([Path] string name, [Path] string webJobName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Stop a continuous web job for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API deletes a deployment for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}/stop?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsStopContinuousWebJobSlotAsync([Path] string name, [Path] string webJobName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List deployments for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/deployments?api-version=2021-03-01")]
        Task<Response<AnyOf<DeploymentCollection, DefaultErrorResponse>>> WebAppsListDeploymentsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get a deployment by its ID for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="id">Deployment ID.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API gets a deployment for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/deployments/{id}?api-version=2021-03-01")]
        Task<Response<AnyOf<Deployment, DefaultErrorResponse>>> WebAppsGetDeploymentSlotAsync([Path] string name, [Path] string id, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Create a deployment for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="id">ID of an existing deployment.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API creates a deployment for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">User credentials used for publishing activity.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/deployments/{id}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Deployment, DefaultErrorResponse>>> WebAppsCreateDeploymentSlotAsync([Path] string name, [Path] string id, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] Deployment content);

        /// <summary>
        /// Delete a deployment by its ID for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="id">Deployment ID.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API deletes a deployment for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/deployments/{id}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteDeploymentSlotAsync([Path] string name, [Path] string id, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List deployment log for specific deployment for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="id">The ID of a specific deployment. This is the value of the name property in the JSON response from "GET /api/sites/{siteName}/deployments".</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/deployments/{id}/log?api-version=2021-03-01")]
        Task<Response<AnyOf<Deployment, DefaultErrorResponse>>> WebAppsListDeploymentLogSlotAsync([Path] string name, [Path] string id, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Discovers an existing app backup that can be restored from a blob in Azure storage. Use this to get information about the databases stored in a backup.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will perform discovery for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Description of a restore request.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/discoverbackup?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<RestoreRequest, DefaultErrorResponse>>> WebAppsDiscoverBackupSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] RestoreRequest content);

        /// <summary>
        /// Lists ownership identifiers for domain associated with web app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will delete the binding for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/domainOwnershipIdentifiers?api-version=2021-03-01")]
        Task<Response<AnyOf<IdentifierCollection, DefaultErrorResponse>>> WebAppsListDomainOwnershipIdentifiersSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get domain ownership identifier for web app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="domainOwnershipIdentifierName">Name of domain ownership identifier.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will delete the binding for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}?api-version=2021-03-01")]
        Task<Response<AnyOf<Identifier, DefaultErrorResponse>>> WebAppsGetDomainOwnershipIdentifierSlotAsync([Path] string name, [Path] string domainOwnershipIdentifierName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a domain ownership identifier for web app, or updates an existing ownership identifier.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="domainOwnershipIdentifierName">Name of domain ownership identifier.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will delete the binding for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">A JSON representation of the domain ownership properties.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Identifier, DefaultErrorResponse>>> WebAppsCreateOrUpdateDomainOwnershipIdentifierSlotAsync([Path] string name, [Path] string domainOwnershipIdentifierName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] Identifier content);

        /// <summary>
        /// Deletes a domain ownership identifier for a web app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="domainOwnershipIdentifierName">Name of domain ownership identifier.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will delete the binding for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteDomainOwnershipIdentifierSlotAsync([Path] string name, [Path] string domainOwnershipIdentifierName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a domain ownership identifier for web app, or updates an existing ownership identifier.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="domainOwnershipIdentifierName">Name of domain ownership identifier.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will delete the binding for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">A JSON representation of the domain ownership properties.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Identifier, DefaultErrorResponse>>> WebAppsUpdateDomainOwnershipIdentifierSlotAsync([Path] string name, [Path] string domainOwnershipIdentifierName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] Identifier content);

        /// <summary>
        /// Get the status of the last MSDeploy operation.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/extensions/MSDeploy?api-version=2021-03-01")]
        Task<Response<AnyOf<MSDeployStatus, DefaultErrorResponse>>> WebAppsGetMSDeployStatusSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Invoke the MSDeploy web app extension.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">MSDeploy ARM PUT information</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/extensions/MSDeploy?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<MSDeployStatus, object, DefaultErrorResponse>>> WebAppsCreateMSDeployOperationSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] MSDeploy content);

        /// <summary>
        /// Get the MSDeploy Log for the last MSDeploy operation.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/extensions/MSDeploy/log?api-version=2021-03-01")]
        Task<Response<AnyOf<MSDeployLog, object, DefaultErrorResponse>>> WebAppsGetMSDeployLogSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List the functions for a web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="slot">Name of the deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions?api-version=2021-03-01")]
        Task<Response<AnyOf<FunctionEnvelopeCollection, object, DefaultErrorResponse>>> WebAppsListInstanceFunctionsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Fetch a short lived token that can be exchanged for a master key.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/admin/token?api-version=2021-03-01")]
        Task<Response<AnyOf<string, DefaultErrorResponse>>> WebAppsGetFunctionsAdminTokenSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get function information by its ID for web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="functionName">Function name.</param>
        /// <param name="slot">Name of the deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}?api-version=2021-03-01")]
        Task<Response<AnyOf<FunctionEnvelope, object, DefaultErrorResponse>>> WebAppsGetInstanceFunctionSlotAsync([Path] string name, [Path] string functionName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Create function for web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="functionName">Function name.</param>
        /// <param name="slot">Name of the deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Function information.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<FunctionEnvelope, DefaultErrorResponse>>> WebAppsCreateInstanceFunctionSlotAsync([Path] string name, [Path] string functionName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] FunctionEnvelope content);

        /// <summary>
        /// Delete a function for web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="functionName">Function name.</param>
        /// <param name="slot">Name of the deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteInstanceFunctionSlotAsync([Path] string name, [Path] string functionName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Add or update a function secret.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="functionName">The name of the function.</param>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="slot">Name of the deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Function key info.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/keys/{keyName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<KeyInfo, DefaultErrorResponse>>> WebAppsCreateOrUpdateFunctionSecretSlotAsync([Path] string name, [Path] string functionName, [Path] string keyName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] KeyInfo content);

        /// <summary>
        /// Delete a function secret.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="functionName">The name of the function.</param>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="slot">Name of the deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/keys/{keyName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteFunctionSecretSlotAsync([Path] string name, [Path] string functionName, [Path] string keyName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get function keys for a function in a web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="functionName">Function name.</param>
        /// <param name="slot">Name of the deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/listkeys?api-version=2021-03-01")]
        Task<Response<AnyOf<StringDictionary, DefaultErrorResponse>>> WebAppsListFunctionKeysSlotAsync([Path] string name, [Path] string functionName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get function secrets for a function in a web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="functionName">Function name.</param>
        /// <param name="slot">Name of the deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/listsecrets?api-version=2021-03-01")]
        Task<Response<AnyOf<FunctionSecrets, DefaultErrorResponse>>> WebAppsListFunctionSecretsSlotAsync([Path] string name, [Path] string functionName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get host secrets for a function app.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="slot">Name of the deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/host/default/listkeys?api-version=2021-03-01")]
        Task<Response<AnyOf<HostKeys, DefaultErrorResponse>>> WebAppsListHostKeysSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// This is to allow calling via powershell and ARM template.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/host/default/listsyncstatus?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsListSyncStatusSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Syncs function trigger metadata to the management database
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/host/default/sync?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsSyncFunctionsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Add or update a host level secret.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="keyType">The type of host key.</param>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="slot">Name of the deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Function key info.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/host/default/{keyType}/{keyName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<KeyInfo, DefaultErrorResponse>>> WebAppsCreateOrUpdateHostSecretSlotAsync([Path] string name, [Path] string keyType, [Path] string keyName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] KeyInfo content);

        /// <summary>
        /// Delete a host level secret.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="keyType">The type of host key.</param>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="slot">Name of the deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/host/default/{keyType}/{keyName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteHostSecretSlotAsync([Path] string name, [Path] string keyType, [Path] string keyName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get hostname bindings for an app or a deployment slot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API gets hostname bindings for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hostNameBindings?api-version=2021-03-01")]
        Task<Response<AnyOf<HostNameBindingCollection, DefaultErrorResponse>>> WebAppsListHostNameBindingsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get the named hostname binding for an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API the named binding for the production slot.</param>
        /// <param name="hostName">Hostname in the hostname binding.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hostNameBindings/{hostName}?api-version=2021-03-01")]
        Task<Response<AnyOf<HostNameBinding, DefaultErrorResponse>>> WebAppsGetHostNameBindingSlotAsync([Path] string name, [Path] string slot, [Path] string hostName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a hostname binding for an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="hostName">Hostname in the hostname binding.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will create a binding for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">A hostname binding object.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hostNameBindings/{hostName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<HostNameBinding, DefaultErrorResponse>>> WebAppsCreateOrUpdateHostNameBindingSlotAsync([Path] string name, [Path] string hostName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] HostNameBinding content);

        /// <summary>
        /// Deletes a hostname binding for an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will delete the binding for the production slot.</param>
        /// <param name="hostName">Hostname in the hostname binding.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hostNameBindings/{hostName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteHostNameBindingSlotAsync([Path] string name, [Path] string slot, [Path] string hostName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Retrieves a specific Service Bus Hybrid Connection used by this Web App.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="namespaceName">The namespace for this hybrid connection.</param>
        /// <param name="relayName">The relay name for this hybrid connection.</param>
        /// <param name="slot">The name of the slot for the web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}?api-version=2021-03-01")]
        Task<Response<AnyOf<HybridConnection, DefaultErrorResponse>>> WebAppsGetHybridConnectionSlotAsync([Path] string name, [Path] string namespaceName, [Path] string relayName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a new Hybrid Connection using a Service Bus relay.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="namespaceName">The namespace for this hybrid connection.</param>
        /// <param name="relayName">The relay name for this hybrid connection.</param>
        /// <param name="slot">The name of the slot for the web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">The details of the hybrid connection.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<HybridConnection, DefaultErrorResponse>>> WebAppsCreateOrUpdateHybridConnectionSlotAsync([Path] string name, [Path] string namespaceName, [Path] string relayName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] HybridConnection content);

        /// <summary>
        /// Removes a Hybrid Connection from this site.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="namespaceName">The namespace for this hybrid connection.</param>
        /// <param name="relayName">The relay name for this hybrid connection.</param>
        /// <param name="slot">The name of the slot for the web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteHybridConnectionSlotAsync([Path] string name, [Path] string namespaceName, [Path] string relayName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a new Hybrid Connection using a Service Bus relay.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="namespaceName">The namespace for this hybrid connection.</param>
        /// <param name="relayName">The relay name for this hybrid connection.</param>
        /// <param name="slot">The name of the slot for the web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">The details of the hybrid connection.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<HybridConnection, DefaultErrorResponse>>> WebAppsUpdateHybridConnectionSlotAsync([Path] string name, [Path] string namespaceName, [Path] string relayName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] HybridConnection content);

        /// <summary>
        /// Retrieves all Service Bus Hybrid Connections used by this Web App.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="slot">The name of the slot for the web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridConnectionRelays?api-version=2021-03-01")]
        Task<Response<AnyOf<HybridConnection, DefaultErrorResponse>>> WebAppsListHybridConnectionsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets hybrid connections configured for an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get hybrid connections for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridconnection?api-version=2021-03-01")]
        Task<Response<AnyOf<RelayServiceConnectionEntity, DefaultErrorResponse>>> WebAppsListRelayServiceConnectionsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a hybrid connection configuration by its name.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="entityName">Name of the hybrid connection.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get a hybrid connection for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridconnection/{entityName}?api-version=2021-03-01")]
        Task<Response<AnyOf<RelayServiceConnectionEntity, DefaultErrorResponse>>> WebAppsGetRelayServiceConnectionSlotAsync([Path] string name, [Path] string entityName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a new hybrid connection configuration (PUT), or updates an existing one (PATCH).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="entityName">Name of the hybrid connection configuration.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will create or update a hybrid connection for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Hybrid Connection for an App Service app.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridconnection/{entityName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<RelayServiceConnectionEntity, DefaultErrorResponse>>> WebAppsCreateOrUpdateRelayServiceConnectionSlotAsync([Path] string name, [Path] string entityName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] RelayServiceConnectionEntity content);

        /// <summary>
        /// Deletes a relay service connection by its name.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="entityName">Name of the hybrid connection configuration.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will delete a hybrid connection for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridconnection/{entityName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteRelayServiceConnectionSlotAsync([Path] string name, [Path] string entityName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a new hybrid connection configuration (PUT), or updates an existing one (PATCH).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="entityName">Name of the hybrid connection configuration.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will create or update a hybrid connection for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Hybrid Connection for an App Service app.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridconnection/{entityName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<RelayServiceConnectionEntity, DefaultErrorResponse>>> WebAppsUpdateRelayServiceConnectionSlotAsync([Path] string name, [Path] string entityName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] RelayServiceConnectionEntity content);

        /// <summary>
        /// Gets all scale-out instances of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API gets the production slot instances.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances?api-version=2021-03-01")]
        Task<Response<AnyOf<WebAppInstanceStatusCollection, DefaultErrorResponse>>> WebAppsListInstanceIdentifiersSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets all scale-out instances of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="instanceId"></param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API gets the production slot instances.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}?api-version=2021-03-01")]
        Task<Response<AnyOf<WebSiteInstanceStatus, DefaultErrorResponse>>> WebAppsGetInstanceInfoSlotAsync([Path] string name, [Path] string instanceId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get the status of the last MSDeploy operation.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="instanceId">ID of web app instance.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/extensions/MSDeploy?api-version=2021-03-01")]
        Task<Response<AnyOf<MSDeployStatus, DefaultErrorResponse>>> WebAppsGetInstanceMsDeployStatusSlotAsync([Path] string name, [Path] string slot, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Invoke the MSDeploy web app extension.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="instanceId">ID of web app instance.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">MSDeploy ARM PUT information</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/extensions/MSDeploy?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<MSDeployStatus, object, DefaultErrorResponse>>> WebAppsCreateInstanceMSDeployOperationSlotAsync([Path] string name, [Path] string slot, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] MSDeploy content);

        /// <summary>
        /// Get the MSDeploy Log for the last MSDeploy operation.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="instanceId">ID of web app instance.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/extensions/MSDeploy/log?api-version=2021-03-01")]
        Task<Response<AnyOf<MSDeployLog, object, DefaultErrorResponse>>> WebAppsGetInstanceMSDeployLogSlotAsync([Path] string name, [Path] string slot, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get list of processes for a web site, or a deployment slot, or for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="instanceId">ID of a specific scaled-out instance. This is the value of the name property in the JSON response from "GET api/sites/{siteName}/instances".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/processes?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessInfoCollection, object, DefaultErrorResponse>>> WebAppsListInstanceProcessesSlotAsync([Path] string name, [Path] string slot, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get process information by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="instanceId">ID of a specific scaled-out instance. This is the value of the name property in the JSON response from "GET api/sites/{siteName}/instances".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/processes/{processId}?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessInfo, object, DefaultErrorResponse>>> WebAppsGetInstanceProcessSlotAsync([Path] string name, [Path] string processId, [Path] string slot, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Terminate a process by its ID for a web site, or a deployment slot, or specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="instanceId">ID of a specific scaled-out instance. This is the value of the name property in the JSON response from "GET api/sites/{siteName}/instances".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/processes/{processId}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteInstanceProcessSlotAsync([Path] string name, [Path] string processId, [Path] string slot, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get a memory dump of a process by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="instanceId">ID of a specific scaled-out instance. This is the value of the name property in the JSON response from "GET api/sites/{siteName}/instances".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/processes/{processId}/dump?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsGetInstanceProcessDumpSlotAsync([Path] string name, [Path] string processId, [Path] string slot, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List module information for a process by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="instanceId">ID of a specific scaled-out instance. This is the value of the name property in the JSON response from "GET api/sites/{siteName}/instances".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/processes/{processId}/modules?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessModuleInfoCollection, object, DefaultErrorResponse>>> WebAppsListInstanceProcessModulesSlotAsync([Path] string name, [Path] string processId, [Path] string slot, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get process information by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="baseAddress">Module base address.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="instanceId">ID of a specific scaled-out instance. This is the value of the name property in the JSON response from "GET api/sites/{siteName}/instances".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/processes/{processId}/modules/{baseAddress}?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessModuleInfo, object, DefaultErrorResponse>>> WebAppsGetInstanceProcessModuleSlotAsync([Path] string name, [Path] string processId, [Path] string baseAddress, [Path] string slot, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List the threads in a process by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="instanceId">ID of a specific scaled-out instance. This is the value of the name property in the JSON response from "GET api/sites/{siteName}/instances".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/processes/{processId}/threads?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessThreadInfoCollection, object, DefaultErrorResponse>>> WebAppsListInstanceProcessThreadsSlotAsync([Path] string name, [Path] string processId, [Path] string slot, [Path] string instanceId, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Shows whether an app can be cloned to another resource group or subscription.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. By default, this API returns information on the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/iscloneable?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteCloneability, DefaultErrorResponse>>> WebAppsIsCloneableSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets existing backups of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get backups of the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/listbackups?api-version=2021-03-01")]
        Task<Response<AnyOf<BackupItemCollection, DefaultErrorResponse>>> WebAppsListSiteBackupsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// This is to allow calling via powershell and ARM template.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/listsyncfunctiontriggerstatus?api-version=2021-03-01")]
        Task<Response<AnyOf<FunctionSecrets, DefaultErrorResponse>>> WebAppsListSyncFunctionTriggersSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Returns the status of MySql in app migration, if one is active, and whether or not MySql in app is enabled
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of the deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/migratemysql/status?api-version=2021-03-01")]
        Task<Response<AnyOf<MigrateMySqlStatus, DefaultErrorResponse>>> WebAppsGetMigrateMySqlStatusSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a Swift Virtual Network connection.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get a gateway for the production slot's Virtual Network.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkConfig/virtualNetwork?api-version=2021-03-01")]
        Task<Response<AnyOf<SwiftVirtualNetwork, DefaultErrorResponse>>> WebAppsGetSwiftVirtualNetworkConnectionSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Integrates this Web App with a Virtual Network. This requires that 1) "swiftSupported" is true when doing a GET against this resource, and 2) that the target Subnet has already been delegated, and is notin use by another App Service Plan other than the one this App is in.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will add or update connections for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Swift Virtual Network Contract. This is used to enable the new Swift way of doing virtual network integration.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkConfig/virtualNetwork?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SwiftVirtualNetwork, DefaultErrorResponse>>> WebAppsCreateOrUpdateSwiftVirtualNetworkConnectionWithCheckSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SwiftVirtualNetwork content);

        /// <summary>
        /// Deletes a Swift Virtual Network connection from an app (or deployment slot).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will delete the connection for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkConfig/virtualNetwork?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteSwiftVirtualNetworkSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Integrates this Web App with a Virtual Network. This requires that 1) "swiftSupported" is true when doing a GET against this resource, and 2) that the target Subnet has already been delegated, and is notin use by another App Service Plan other than the one this App is in.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will add or update connections for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Swift Virtual Network Contract. This is used to enable the new Swift way of doing virtual network integration.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkConfig/virtualNetwork?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SwiftVirtualNetwork, DefaultErrorResponse>>> WebAppsUpdateSwiftVirtualNetworkConnectionWithCheckSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SwiftVirtualNetwork content);

        /// <summary>
        /// Gets all network features used by the app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="view">The type of view. Only "summary" is supported at this time.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get network features for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkFeatures/{view}?api-version=2021-03-01")]
        Task<Response<AnyOf<NetworkFeatures, object, DefaultErrorResponse>>> WebAppsListNetworkFeaturesSlotAsync([Path] string name, [Path] string view, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a named operation for a network trace capturing (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="operationId">GUID of the operation.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get an operation for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTrace/operationresults/{operationId}?api-version=2021-03-01")]
        Task<Response<AnyOf<NetworkTrace[], DefaultErrorResponse>>> WebAppsGetNetworkTraceOperationSlotAsync([Path] string name, [Path] string operationId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Start capturing network packets for the site (To be deprecated).
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="slot">The name of the slot for this web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="durationInSeconds">The duration to keep capturing in seconds.</param>
        /// <param name="maxFrameLength">The maximum frame length in bytes (Optional).</param>
        /// <param name="sasUrl">The Blob URL to store capture file.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTrace/start?api-version=2021-03-01")]
        Task<Response<AnyOf<string, DefaultErrorResponse>>> WebAppsStartWebSiteNetworkTraceSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Query] int? durationInSeconds, [Query] int? maxFrameLength, [Query] string sasUrl);

        /// <summary>
        /// Start capturing network packets for the site.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="slot">The name of the slot for this web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="durationInSeconds">The duration to keep capturing in seconds.</param>
        /// <param name="maxFrameLength">The maximum frame length in bytes (Optional).</param>
        /// <param name="sasUrl">The Blob URL to store capture file.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTrace/startOperation?api-version=2021-03-01")]
        Task<Response<AnyOf<NetworkTrace[], DefaultErrorResponse>>> WebAppsStartWebSiteNetworkTraceOperationSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Query] int? durationInSeconds, [Query] int? maxFrameLength, [Query] string sasUrl);

        /// <summary>
        /// Stop ongoing capturing network packets for the site.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="slot">The name of the slot for this web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTrace/stop?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsStopWebSiteNetworkTraceSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a named operation for a network trace capturing (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="operationId">GUID of the operation.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get an operation for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTrace/{operationId}?api-version=2021-03-01")]
        Task<Response<AnyOf<NetworkTrace[], DefaultErrorResponse>>> WebAppsGetNetworkTracesSlotAsync([Path] string name, [Path] string operationId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a named operation for a network trace capturing (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="operationId">GUID of the operation.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get an operation for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTraces/current/operationresults/{operationId}?api-version=2021-03-01")]
        Task<Response<AnyOf<NetworkTrace[], DefaultErrorResponse>>> WebAppsGetNetworkTraceOperationSlotV2Async([Path] string name, [Path] string operationId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a named operation for a network trace capturing (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="operationId">GUID of the operation.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get an operation for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTraces/{operationId}?api-version=2021-03-01")]
        Task<Response<AnyOf<NetworkTrace[], DefaultErrorResponse>>> WebAppsGetNetworkTracesSlotV2Async([Path] string name, [Path] string operationId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Generates a new publishing password for an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API generate a new publishing password for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/newpassword?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsGenerateNewSitePublishingPasswordSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets perfmon counters for web app.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="filter">Return only usages/metrics specified in the filter. Filter conforms to odata syntax. Example: $filter=(startTime eq 2014-01-01T00:00:00Z and endTime eq 2014-12-31T23:59:59Z and timeGrain eq duration'[Hour|Minute|Day]'.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/perfcounters?api-version=2021-03-01")]
        Task<Response<AnyOf<PerfMonCounterCollection, DefaultErrorResponse>>> WebAppsListPerfMonCountersSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Query(Name = "$filter")] string filter);

        /// <summary>
        /// Gets web app's event logs.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/phplogging?api-version=2021-03-01")]
        Task<Response<AnyOf<SitePhpErrorLogFlag, DefaultErrorResponse>>> WebAppsGetSitePhpErrorLogFlagSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the premier add-ons of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get the premier add-ons for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons?api-version=2021-03-01")]
        Task<Response<AnyOf<PremierAddOn, DefaultErrorResponse>>> WebAppsListPremierAddOnsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a named add-on of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="premierAddOnName">Add-on name.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get the named add-on for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}?api-version=2021-03-01")]
        Task<Response<AnyOf<PremierAddOn, DefaultErrorResponse>>> WebAppsGetPremierAddOnSlotAsync([Path] string name, [Path] string premierAddOnName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates a named add-on of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="premierAddOnName">Add-on name.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will update the named add-on for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Premier add-on.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PremierAddOn, DefaultErrorResponse>>> WebAppsAddPremierAddOnSlotAsync([Path] string name, [Path] string premierAddOnName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] PremierAddOn content);

        /// <summary>
        /// Delete a premier add-on from an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="premierAddOnName">Add-on name.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will delete the named add-on for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeletePremierAddOnSlotAsync([Path] string name, [Path] string premierAddOnName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates a named add-on of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="premierAddOnName">Add-on name.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will update the named add-on for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">ARM resource for a PremierAddOn.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PremierAddOn, DefaultErrorResponse>>> WebAppsUpdatePremierAddOnSlotAsync([Path] string name, [Path] string premierAddOnName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] PremierAddOnPatchResource content);

        /// <summary>
        /// Gets data around private site access enablement and authorized Virtual Networks that can access the site.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="slot">The name of the slot for the web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateAccess/virtualNetworks?api-version=2021-03-01")]
        Task<Response<AnyOf<PrivateAccess, DefaultErrorResponse>>> WebAppsGetPrivateAccessSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Sets data around private site access enablement and authorized Virtual Networks that can access the site.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="slot">The name of the slot for the web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Description of the parameters of Private Access for a Web Site.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateAccess/virtualNetworks?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PrivateAccess, DefaultErrorResponse>>> WebAppsPutPrivateAccessVnetSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] PrivateAccess content);

        /// <summary>
        /// Gets the list of private endpoint connections associated with a site
        /// </summary>
        /// <param name="name">Name of the site.</param>
        /// <param name="slot">Name of the site deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateEndpointConnections?api-version=2021-03-01")]
        Task<Response<AnyOf<PrivateEndpointConnectionCollection, DefaultErrorResponse>>> WebAppsGetPrivateEndpointConnectionListSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a private endpoint connection
        /// </summary>
        /// <param name="name">Name of the site.</param>
        /// <param name="privateEndpointConnectionName">Name of the private endpoint connection.</param>
        /// <param name="slot">Name of the site deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateEndpointConnections/{privateEndpointConnectionName}?api-version=2021-03-01")]
        Task<Response<AnyOf<RemotePrivateEndpointConnectionARMResource, DefaultErrorResponse>>> WebAppsGetPrivateEndpointConnectionSlotAsync([Path] string name, [Path] string privateEndpointConnectionName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Approves or rejects a private endpoint connection
        /// </summary>
        /// <param name="name">Name of the site.</param>
        /// <param name="privateEndpointConnectionName"></param>
        /// <param name="slot"></param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content"></param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateEndpointConnections/{privateEndpointConnectionName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<RemotePrivateEndpointConnectionARMResource, DefaultErrorResponse>>> WebAppsApproveOrRejectPrivateEndpointConnectionSlotAsync([Path] string name, [Path] string privateEndpointConnectionName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] PrivateLinkConnectionApprovalRequestResource content);

        /// <summary>
        /// Deletes a private endpoint connection
        /// </summary>
        /// <param name="name">Name of the site.</param>
        /// <param name="privateEndpointConnectionName"></param>
        /// <param name="slot"></param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateEndpointConnections/{privateEndpointConnectionName}?api-version=2021-03-01")]
        Task<Response<AnyOf<WebAppsDeletePrivateEndpointConnectionSlotResult, DefaultErrorResponse>>> WebAppsDeletePrivateEndpointConnectionSlotAsync([Path] string name, [Path] string privateEndpointConnectionName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the private link resources
        /// </summary>
        /// <param name="name">Name of the site.</param>
        /// <param name="slot"></param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateLinkResources?api-version=2021-03-01")]
        Task<Response<AnyOf<PrivateLinkResourcesWrapper, DefaultErrorResponse>>> WebAppsGetPrivateLinkResourcesSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get list of processes for a web site, or a deployment slot, or for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessInfoCollection, object, DefaultErrorResponse>>> WebAppsListProcessesSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get process information by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes/{processId}?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessInfo, object, DefaultErrorResponse>>> WebAppsGetProcessSlotAsync([Path] string name, [Path] string processId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Terminate a process by its ID for a web site, or a deployment slot, or specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes/{processId}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteProcessSlotAsync([Path] string name, [Path] string processId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get a memory dump of a process by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes/{processId}/dump?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsGetProcessDumpSlotAsync([Path] string name, [Path] string processId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List module information for a process by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes/{processId}/modules?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessModuleInfoCollection, object, DefaultErrorResponse>>> WebAppsListProcessModulesSlotAsync([Path] string name, [Path] string processId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get process information by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="baseAddress">Module base address.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes/{processId}/modules/{baseAddress}?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessModuleInfo, object, DefaultErrorResponse>>> WebAppsGetProcessModuleSlotAsync([Path] string name, [Path] string processId, [Path] string baseAddress, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List the threads in a process by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="processId">PID.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes/{processId}/threads?api-version=2021-03-01")]
        Task<Response<AnyOf<ProcessThreadInfoCollection, object, DefaultErrorResponse>>> WebAppsListProcessThreadsSlotAsync([Path] string name, [Path] string processId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get public certificates for an app or a deployment slot.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API gets hostname bindings for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/publicCertificates?api-version=2021-03-01")]
        Task<Response<AnyOf<PublicCertificateCollection, DefaultErrorResponse>>> WebAppsListPublicCertificatesSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get the named public certificate for an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API the named binding for the production slot.</param>
        /// <param name="publicCertificateName">Public certificate name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/publicCertificates/{publicCertificateName}?api-version=2021-03-01")]
        Task<Response<AnyOf<PublicCertificate, DefaultErrorResponse>>> WebAppsGetPublicCertificateSlotAsync([Path] string name, [Path] string slot, [Path] string publicCertificateName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Creates a hostname binding for an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="publicCertificateName">Public certificate name.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will create a binding for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Public certificate object</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/publicCertificates/{publicCertificateName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PublicCertificate, DefaultErrorResponse>>> WebAppsCreateOrUpdatePublicCertificateSlotAsync([Path] string name, [Path] string publicCertificateName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] PublicCertificate content);

        /// <summary>
        /// Deletes a hostname binding for an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will delete the binding for the production slot.</param>
        /// <param name="publicCertificateName">Public certificate name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/publicCertificates/{publicCertificateName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeletePublicCertificateSlotAsync([Path] string name, [Path] string slot, [Path] string publicCertificateName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the publishing profile for an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get the publishing profile for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Publishing options for requested profile.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/publishxml?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<object> WebAppsListPublishingProfileXmlWithSecretsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] CsmPublishingProfileOptions content);

        /// <summary>
        /// Resets the configuration settings of the current slot if they were previously modified by calling the API with POST.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API resets configuration settings for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/resetSlotConfig?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsResetSlotConfigurationSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Restarts an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will restart the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="softRestart">Specify true to apply the configuration settings and restarts the app only if necessary. By default, the API always restarts and reprovisions the app.</param>
        /// <param name="synchronous">Specify true to block until the app is restarted. By default, it is set to false, and the API responds immediately (asynchronous).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/restart?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsRestartSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Query] bool? softRestart, [Query] bool? synchronous);

        /// <summary>
        /// Restores an app from a backup blob in Azure Storage.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will restore a backup of the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Description of a restore request.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/restoreFromBackupBlob?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsRestoreFromBackupBlobSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] RestoreRequest content);

        /// <summary>
        /// Restores a deleted web app to this web app.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Details about restoring a deleted app.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/restoreFromDeletedApp?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsRestoreFromDeletedAppSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] DeletedAppRestoreRequest content);

        /// <summary>
        /// Restores a web app from a snapshot.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Details about app recovery operation.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/restoreSnapshot?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsRestoreSnapshotSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SnapshotRestoreRequest content);

        /// <summary>
        /// Get list of siteextensions for a web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API uses the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/siteextensions?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteExtensionInfoCollection, object, DefaultErrorResponse>>> WebAppsListSiteExtensionsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get site extension information by its ID for a web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="siteExtensionId">Site extension name.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API uses the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/siteextensions/{siteExtensionId}?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteExtensionInfo, object, DefaultErrorResponse>>> WebAppsGetSiteExtensionSlotAsync([Path] string name, [Path] string siteExtensionId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Install site extension on a web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="siteExtensionId">Site extension name.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API uses the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/siteextensions/{siteExtensionId}?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteExtensionInfo, object, DefaultErrorResponse>>> WebAppsInstallSiteExtensionSlotAsync([Path] string name, [Path] string siteExtensionId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Remove a site extension from a web site, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="siteExtensionId">Site extension name.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API deletes a deployment for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/siteextensions/{siteExtensionId}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteSiteExtensionSlotAsync([Path] string name, [Path] string siteExtensionId, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get the difference in configuration settings between two web app slots.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the source slot. If a slot is not specified, the production slot is used as the source slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Deployment slot parameters.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/slotsdiffs?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SlotDifferenceCollection, DefaultErrorResponse>>> WebAppsListSlotDifferencesSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] CsmSlotEntity content);

        /// <summary>
        /// Swaps two deployment slots of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the source slot. If a slot is not specified, the production slot is used as the source slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Deployment slot parameters.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/slotsswap?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsSwapSlotSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] CsmSlotEntity content);

        /// <summary>
        /// Returns all Snapshots to the user.
        /// </summary>
        /// <param name="name">Website Name.</param>
        /// <param name="slot">Website Slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/snapshots?api-version=2021-03-01")]
        Task<Response<AnyOf<SnapshotCollection, DefaultErrorResponse>>> WebAppsListSnapshotsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Returns all Snapshots to the user from DRSecondary endpoint.
        /// </summary>
        /// <param name="name">Website Name.</param>
        /// <param name="slot">Website Slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/snapshotsdr?api-version=2021-03-01")]
        Task<Response<AnyOf<SnapshotCollection, DefaultErrorResponse>>> WebAppsListSnapshotsFromDRSecondarySlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the source control configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get the source control configuration for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sourcecontrols/web?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteSourceControl, DefaultErrorResponse>>> WebAppsGetSourceControlSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates the source control configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will update the source control configuration for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Source control configuration for an app.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sourcecontrols/web?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SiteSourceControl, DefaultErrorResponse>>> WebAppsCreateOrUpdateSourceControlSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SiteSourceControl content);

        /// <summary>
        /// Deletes the source control configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will delete the source control configuration for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="additionalFlags"></param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sourcecontrols/web?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteSourceControlSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Query] string additionalFlags);

        /// <summary>
        /// Updates the source control configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will update the source control configuration for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Source control configuration for an app.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sourcecontrols/web?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SiteSourceControl, DefaultErrorResponse>>> WebAppsUpdateSourceControlSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SiteSourceControl content);

        /// <summary>
        /// Starts an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will start the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/start?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsStartSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Start capturing network packets for the site.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="slot">The name of the slot for this web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="durationInSeconds">The duration to keep capturing in seconds.</param>
        /// <param name="maxFrameLength">The maximum frame length in bytes (Optional).</param>
        /// <param name="sasUrl">The Blob URL to store capture file.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/startNetworkTrace?api-version=2021-03-01")]
        Task<Response<AnyOf<NetworkTrace[], DefaultErrorResponse>>> WebAppsStartNetworkTraceSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Query] int? durationInSeconds, [Query] int? maxFrameLength, [Query] string sasUrl);

        /// <summary>
        /// Stops an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will stop the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/stop?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsStopSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Stop ongoing capturing network packets for the site.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="slot">The name of the slot for this web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/stopNetworkTrace?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsStopNetworkTraceSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Sync web app repository.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="slot">Name of web app slot. If not specified then will default to production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sync?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsSyncRepositorySlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Syncs function trigger metadata to the management database
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/syncfunctiontriggers?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsSyncFunctionTriggersSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List triggered web jobs for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API deletes a deployment for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs?api-version=2021-03-01")]
        Task<Response<AnyOf<TriggeredWebJobCollection, DefaultErrorResponse>>> WebAppsListTriggeredWebJobsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a triggered web job by its ID for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API uses the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}?api-version=2021-03-01")]
        Task<Response<AnyOf<TriggeredWebJob, object, DefaultErrorResponse>>> WebAppsGetTriggeredWebJobSlotAsync([Path] string name, [Path] string webJobName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Delete a triggered web job by its ID for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API deletes web job for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteTriggeredWebJobSlotAsync([Path] string name, [Path] string webJobName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List a triggered web job's history for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API uses the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/history?api-version=2021-03-01")]
        Task<Response<AnyOf<TriggeredJobHistoryCollection, object, DefaultErrorResponse>>> WebAppsListTriggeredWebJobHistorySlotAsync([Path] string name, [Path] string webJobName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a triggered web job's history by its ID for an app, , or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="id">History ID.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API uses the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/history/{id}?api-version=2021-03-01")]
        Task<Response<AnyOf<TriggeredJobHistory, object, DefaultErrorResponse>>> WebAppsGetTriggeredWebJobHistorySlotAsync([Path] string name, [Path] string webJobName, [Path] string id, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Run a triggered web job for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API uses the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/run?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsRunTriggeredWebJobSlotAsync([Path] string name, [Path] string webJobName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the quota usage information of an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get quota information of the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="filter">Return only information specified in the filter (using OData syntax). For example: $filter=(name.value eq 'Metric1' or name.value eq 'Metric2') and startTime eq 2014-01-01T00:00:00Z and endTime eq 2014-12-31T23:59:59Z and timeGrain eq duration'[Hour|Minute|Day]'.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/usages?api-version=2021-03-01")]
        Task<Response<AnyOf<CsmUsageQuotaCollection, DefaultErrorResponse>>> WebAppsListUsagesSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Query(Name = "$filter")] string filter);

        /// <summary>
        /// Gets the virtual networks the app (or deployment slot) is connected to.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get virtual network connections for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections?api-version=2021-03-01")]
        Task<Response<AnyOf<VnetInfoResource[], DefaultErrorResponse>>> WebAppsListVnetConnectionsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a virtual network the app (or deployment slot) is connected to by name.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="vnetName">Name of the virtual network.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get the named virtual network for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections/{vnetName}?api-version=2021-03-01")]
        Task<Response<AnyOf<VnetInfoResource, DefaultErrorResponse>>> WebAppsGetVnetConnectionSlotAsync([Path] string name, [Path] string vnetName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Adds a Virtual Network connection to an app or slot (PUT) or updates the connection properties (PATCH).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="vnetName">Name of an existing Virtual Network.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will add or update connections for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Properties of the Virtual Network connection. See example.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections/{vnetName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<VnetInfoResource, DefaultErrorResponse>>> WebAppsCreateOrUpdateVnetConnectionSlotAsync([Path] string name, [Path] string vnetName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] VnetInfoResource content);

        /// <summary>
        /// Deletes a connection from an app (or deployment slot to a named virtual network.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="vnetName">Name of the virtual network.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will delete the connection for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections/{vnetName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteVnetConnectionSlotAsync([Path] string name, [Path] string vnetName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Adds a Virtual Network connection to an app or slot (PUT) or updates the connection properties (PATCH).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="vnetName">Name of an existing Virtual Network.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will add or update connections for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Properties of the Virtual Network connection. See example.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections/{vnetName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<VnetInfoResource, DefaultErrorResponse>>> WebAppsUpdateVnetConnectionSlotAsync([Path] string name, [Path] string vnetName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] VnetInfoResource content);

        /// <summary>
        /// Gets an app's Virtual Network gateway.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="vnetName">Name of the Virtual Network.</param>
        /// <param name="gatewayName">Name of the gateway. Currently, the only supported string is "primary".</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will get a gateway for the production slot's Virtual Network.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections/{vnetName}/gateways/{gatewayName}?api-version=2021-03-01")]
        Task<Response<AnyOf<VnetGateway, object, DefaultErrorResponse>>> WebAppsGetVnetConnectionGatewaySlotAsync([Path] string name, [Path] string vnetName, [Path] string gatewayName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Adds a gateway to a connected Virtual Network (PUT) or updates it (PATCH).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="vnetName">Name of the Virtual Network.</param>
        /// <param name="gatewayName">Name of the gateway. Currently, the only supported string is "primary".</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will add or update a gateway for the production slot's Virtual Network.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">The properties to update this gateway with.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections/{vnetName}/gateways/{gatewayName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<VnetGateway, DefaultErrorResponse>>> WebAppsCreateOrUpdateVnetConnectionGatewaySlotAsync([Path] string name, [Path] string vnetName, [Path] string gatewayName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] VnetGateway content);

        /// <summary>
        /// Adds a gateway to a connected Virtual Network (PUT) or updates it (PATCH).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="vnetName">Name of the Virtual Network.</param>
        /// <param name="gatewayName">Name of the gateway. Currently, the only supported string is "primary".</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API will add or update a gateway for the production slot's Virtual Network.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">The properties to update this gateway with.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections/{vnetName}/gateways/{gatewayName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<VnetGateway, DefaultErrorResponse>>> WebAppsUpdateVnetConnectionGatewaySlotAsync([Path] string name, [Path] string vnetName, [Path] string gatewayName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] VnetGateway content);

        /// <summary>
        /// List webjobs for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/webjobs?api-version=2021-03-01")]
        Task<Response<AnyOf<WebJobCollection, DefaultErrorResponse>>> WebAppsListWebJobsSlotAsync([Path] string name, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get webjob information for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of the web job.</param>
        /// <param name="slot">Name of the deployment slot. If a slot is not specified, the API returns deployments for the production slot.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/webjobs/{webJobName}?api-version=2021-03-01")]
        Task<Response<AnyOf<WebJob, DefaultErrorResponse>>> WebAppsGetWebJobSlotAsync([Path] string name, [Path] string webJobName, [Path] string slot, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get the difference in configuration settings between two web app slots.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Deployment slot parameters.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slotsdiffs?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SlotDifferenceCollection, DefaultErrorResponse>>> WebAppsListSlotDifferencesFromProductionAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] CsmSlotEntity content);

        /// <summary>
        /// Swaps two deployment slots of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Deployment slot parameters.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slotsswap?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsSwapSlotWithProductionAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] CsmSlotEntity content);

        /// <summary>
        /// Returns all Snapshots to the user.
        /// </summary>
        /// <param name="name">Website Name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/snapshots?api-version=2021-03-01")]
        Task<Response<AnyOf<SnapshotCollection, DefaultErrorResponse>>> WebAppsListSnapshotsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Returns all Snapshots to the user from DRSecondary endpoint.
        /// </summary>
        /// <param name="name">Website Name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/snapshotsdr?api-version=2021-03-01")]
        Task<Response<AnyOf<SnapshotCollection, DefaultErrorResponse>>> WebAppsListSnapshotsFromDRSecondaryAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the source control configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/sourcecontrols/web?api-version=2021-03-01")]
        Task<Response<AnyOf<SiteSourceControl, DefaultErrorResponse>>> WebAppsGetSourceControlAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Updates the source control configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Source control configuration for an app.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/sourcecontrols/web?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SiteSourceControl, DefaultErrorResponse>>> WebAppsCreateOrUpdateSourceControlAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SiteSourceControl content);

        /// <summary>
        /// Deletes the source control configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="additionalFlags"></param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/sourcecontrols/web?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteSourceControlAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Query] string additionalFlags);

        /// <summary>
        /// Updates the source control configuration of an app.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Source control configuration for an app.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/sourcecontrols/web?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SiteSourceControl, DefaultErrorResponse>>> WebAppsUpdateSourceControlAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] SiteSourceControl content);

        /// <summary>
        /// Starts an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/start?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsStartAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Start capturing network packets for the site.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="durationInSeconds">The duration to keep capturing in seconds.</param>
        /// <param name="maxFrameLength">The maximum frame length in bytes (Optional).</param>
        /// <param name="sasUrl">The Blob URL to store capture file.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/startNetworkTrace?api-version=2021-03-01")]
        Task<Response<AnyOf<NetworkTrace[], DefaultErrorResponse>>> WebAppsStartNetworkTraceAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Query] int? durationInSeconds, [Query] int? maxFrameLength, [Query] string sasUrl);

        /// <summary>
        /// Stops an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/stop?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsStopAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Stop ongoing capturing network packets for the site.
        /// </summary>
        /// <param name="name">The name of the web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/stopNetworkTrace?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsStopNetworkTraceAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Sync web app repository.
        /// </summary>
        /// <param name="name">Name of web app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/sync?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsSyncRepositoryAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Syncs function trigger metadata to the management database
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/syncfunctiontriggers?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsSyncFunctionTriggersAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List triggered web jobs for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs?api-version=2021-03-01")]
        Task<Response<AnyOf<TriggeredWebJobCollection, DefaultErrorResponse>>> WebAppsListTriggeredWebJobsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a triggered web job by its ID for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}?api-version=2021-03-01")]
        Task<Response<AnyOf<TriggeredWebJob, object, DefaultErrorResponse>>> WebAppsGetTriggeredWebJobAsync([Path] string name, [Path] string webJobName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Delete a triggered web job by its ID for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteTriggeredWebJobAsync([Path] string name, [Path] string webJobName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// List a triggered web job's history for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/history?api-version=2021-03-01")]
        Task<Response<AnyOf<TriggeredJobHistoryCollection, object, DefaultErrorResponse>>> WebAppsListTriggeredWebJobHistoryAsync([Path] string name, [Path] string webJobName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a triggered web job's history by its ID for an app, , or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="id">History ID.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/history/{id}?api-version=2021-03-01")]
        Task<Response<AnyOf<TriggeredJobHistory, object, DefaultErrorResponse>>> WebAppsGetTriggeredWebJobHistoryAsync([Path] string name, [Path] string webJobName, [Path] string id, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Run a triggered web job for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of Web Job.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/run?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsRunTriggeredWebJobAsync([Path] string name, [Path] string webJobName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets the quota usage information of an app (or deployment slot, if specified).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="filter">Return only information specified in the filter (using OData syntax). For example: $filter=(name.value eq 'Metric1' or name.value eq 'Metric2') and startTime eq 2014-01-01T00:00:00Z and endTime eq 2014-12-31T23:59:59Z and timeGrain eq duration'[Hour|Minute|Day]'.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/usages?api-version=2021-03-01")]
        Task<Response<AnyOf<CsmUsageQuotaCollection, DefaultErrorResponse>>> WebAppsListUsagesAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId, [Query(Name = "$filter")] string filter);

        /// <summary>
        /// Gets the virtual networks the app (or deployment slot) is connected to.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections?api-version=2021-03-01")]
        Task<Response<AnyOf<VnetInfoResource[], DefaultErrorResponse>>> WebAppsListVnetConnectionsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Gets a virtual network the app (or deployment slot) is connected to by name.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="vnetName">Name of the virtual network.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}?api-version=2021-03-01")]
        Task<Response<AnyOf<VnetInfoResource, DefaultErrorResponse>>> WebAppsGetVnetConnectionAsync([Path] string name, [Path] string vnetName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Adds a Virtual Network connection to an app or slot (PUT) or updates the connection properties (PATCH).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="vnetName">Name of an existing Virtual Network.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Properties of the Virtual Network connection. See example.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<VnetInfoResource, DefaultErrorResponse>>> WebAppsCreateOrUpdateVnetConnectionAsync([Path] string name, [Path] string vnetName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] VnetInfoResource content);

        /// <summary>
        /// Deletes a connection from an app (or deployment slot to a named virtual network.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="vnetName">Name of the virtual network.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> WebAppsDeleteVnetConnectionAsync([Path] string name, [Path] string vnetName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Adds a Virtual Network connection to an app or slot (PUT) or updates the connection properties (PATCH).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="vnetName">Name of an existing Virtual Network.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">Properties of the Virtual Network connection. See example.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<VnetInfoResource, DefaultErrorResponse>>> WebAppsUpdateVnetConnectionAsync([Path] string name, [Path] string vnetName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] VnetInfoResource content);

        /// <summary>
        /// Gets an app's Virtual Network gateway.
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="vnetName">Name of the Virtual Network.</param>
        /// <param name="gatewayName">Name of the gateway. Currently, the only supported string is "primary".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}/gateways/{gatewayName}?api-version=2021-03-01")]
        Task<Response<AnyOf<VnetGateway, object, DefaultErrorResponse>>> WebAppsGetVnetConnectionGatewayAsync([Path] string name, [Path] string vnetName, [Path] string gatewayName, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Adds a gateway to a connected Virtual Network (PUT) or updates it (PATCH).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="vnetName">Name of the Virtual Network.</param>
        /// <param name="gatewayName">Name of the gateway. Currently, the only supported string is "primary".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">The properties to update this gateway with.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}/gateways/{gatewayName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<VnetGateway, DefaultErrorResponse>>> WebAppsCreateOrUpdateVnetConnectionGatewayAsync([Path] string name, [Path] string vnetName, [Path] string gatewayName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] VnetGateway content);

        /// <summary>
        /// Adds a gateway to a connected Virtual Network (PUT) or updates it (PATCH).
        /// </summary>
        /// <param name="name">Name of the app.</param>
        /// <param name="vnetName">Name of the Virtual Network.</param>
        /// <param name="gatewayName">Name of the gateway. Currently, the only supported string is "primary".</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="content">The properties to update this gateway with.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}/gateways/{gatewayName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<VnetGateway, DefaultErrorResponse>>> WebAppsUpdateVnetConnectionGatewayAsync([Path] string name, [Path] string vnetName, [Path] string gatewayName, [Path] string resourceGroupName, [Path] string subscriptionId, [Body] VnetGateway content);

        /// <summary>
        /// List webjobs for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs?api-version=2021-03-01")]
        Task<Response<AnyOf<WebJobCollection, DefaultErrorResponse>>> WebAppsListWebJobsAsync([Path] string name, [Path] string resourceGroupName, [Path] string subscriptionId);

        /// <summary>
        /// Get webjob information for an app, or a deployment slot.
        /// </summary>
        /// <param name="name">Site name.</param>
        /// <param name="webJobName">Name of the web job.</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs/{webJobName}?api-version=2021-03-01")]
        Task<Response<AnyOf<WebJob, DefaultErrorResponse>>> WebAppsGetWebJobAsync([Path] string name, [Path] string webJobName, [Path] string resourceGroupName, [Path] string subscriptionId);
    }
}