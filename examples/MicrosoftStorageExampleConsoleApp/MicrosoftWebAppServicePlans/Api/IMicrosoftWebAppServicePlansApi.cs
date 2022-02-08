using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnyOfTypes;
using RestEase;
using MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Api
{
    /// <summary>
    /// MicrosoftWebAppServicePlans
    /// </summary>
    public interface IMicrosoftWebAppServicePlansApi
    {
        /// <summary>
        /// Get all App Service plans for a subscription.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="detailed">Specify true to return all App Service plan properties. The default is false, which returns a subset of the properties. Retrieval of all properties may increase the API latency.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.Web/serverfarms?api-version=2021-03-01")]
        Task<Response<AnyOf<AppServicePlanCollection, DefaultErrorResponse>>> AppServicePlansListAsync([Path] string subscriptionId, [Query] bool? detailed);

        /// <summary>
        /// Get all App Service plans in a resource group.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms?api-version=2021-03-01")]
        Task<Response<AnyOf<AppServicePlanCollection, DefaultErrorResponse>>> AppServicePlansListByResourceGroupAsync([Path] string subscriptionId, [Path] string resourceGroupName);

        /// <summary>
        /// Get an App Service plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}?api-version=2021-03-01")]
        Task<Response<AnyOf<AppServicePlan, object, DefaultErrorResponse>>> AppServicePlansGetAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name);

        /// <summary>
        /// Creates or updates an App Service Plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        /// <param name="content">Details of the App Service plan.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<AppServicePlan, DefaultErrorResponse>>> AppServicePlansCreateOrUpdateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Body] AppServicePlan content);

        /// <summary>
        /// Delete an App Service plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> AppServicePlansDeleteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name);

        /// <summary>
        /// Creates or updates an App Service Plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        /// <param name="content">ARM resource for a app service plan.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<AppServicePlan, DefaultErrorResponse>>> AppServicePlansUpdateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Body] AppServicePlanPatchResource content);

        /// <summary>
        /// List all capabilities of an App Service plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/capabilities?api-version=2021-03-01")]
        Task<Response<AnyOf<Capability[], DefaultErrorResponse>>> AppServicePlansListCapabilitiesAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name);

        /// <summary>
        /// Retrieve a Hybrid Connection in use in an App Service plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        /// <param name="namespaceName">Name of the Service Bus namespace.</param>
        /// <param name="relayName">Name of the Service Bus relay.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}?api-version=2021-03-01")]
        Task<Response<AnyOf<HybridConnection, DefaultErrorResponse>>> AppServicePlansGetHybridConnectionAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Path] string namespaceName, [Path] string relayName);

        /// <summary>
        /// Delete a Hybrid Connection in use in an App Service plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        /// <param name="namespaceName">Name of the Service Bus namespace.</param>
        /// <param name="relayName">Name of the Service Bus relay.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> AppServicePlansDeleteHybridConnectionAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Path] string namespaceName, [Path] string relayName);

        /// <summary>
        /// Get the send key name and value of a Hybrid Connection.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        /// <param name="namespaceName">The name of the Service Bus namespace.</param>
        /// <param name="relayName">The name of the Service Bus relay.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}/listKeys?api-version=2021-03-01")]
        Task<Response<AnyOf<HybridConnectionKey, DefaultErrorResponse>>> AppServicePlansListHybridConnectionKeysAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Path] string namespaceName, [Path] string relayName);

        /// <summary>
        /// Get all apps that use a Hybrid Connection in an App Service Plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        /// <param name="namespaceName">Name of the Hybrid Connection namespace.</param>
        /// <param name="relayName">Name of the Hybrid Connection relay.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}/sites?api-version=2021-03-01")]
        Task<Response<AnyOf<ResourceCollection, DefaultErrorResponse>>> AppServicePlansListWebAppsByHybridConnectionAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Path] string namespaceName, [Path] string relayName);

        /// <summary>
        /// Get the maximum number of Hybrid Connections allowed in an App Service plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionPlanLimits/limit?api-version=2021-03-01")]
        Task<Response<AnyOf<HybridConnectionLimits, DefaultErrorResponse>>> AppServicePlansGetHybridConnectionPlanLimitAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name);

        /// <summary>
        /// Retrieve all Hybrid Connections in use in an App Service plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionRelays?api-version=2021-03-01")]
        Task<Response<AnyOf<HybridConnectionCollection, DefaultErrorResponse>>> AppServicePlansListHybridConnectionsAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name);

        /// <summary>
        /// Restart all apps in an App Service plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        /// <param name="softRestart">Specify true to perform a soft restart, applies the configuration settings and restarts the apps if necessary. The default is false, which always restarts and reprovisions the apps</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/restartSites?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> AppServicePlansRestartWebAppsAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Query] bool? softRestart);

        /// <summary>
        /// Get all apps associated with an App Service plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        /// <param name="skipToken">Skip to a web app in the list of webapps associated with app service plan. If specified, the resulting list will contain web apps starting from (including) the skipToken. Otherwise, the resulting list contains web apps from the start of the list</param>
        /// <param name="filter">Supported filter: $filter=state eq running. Returns only web apps that are currently running</param>
        /// <param name="top">List page size. If specified, results are paged.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/sites?api-version=2021-03-01")]
        Task<Response<AnyOf<WebAppCollection, DefaultErrorResponse>>> AppServicePlansListWebAppsAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Query(Name = "$skipToken")] string skipToken, [Query(Name = "$filter")] string filter, [Query(Name = "$top")] string top);

        /// <summary>
        /// Gets all selectable SKUs for a given App Service Plan
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of App Service Plan</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/skus?api-version=2021-03-01")]
        Task<Response<AnyOf<AppServicePlansGetServerFarmSkusResult, DefaultErrorResponse>>> AppServicePlansGetServerFarmSkusAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name);

        /// <summary>
        /// Gets server farm usage information
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of App Service Plan</param>
        /// <param name="filter">Return only usages/metrics specified in the filter. Filter conforms to odata syntax. Example: $filter=(name.value eq 'Metric1' or name.value eq 'Metric2').</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/usages?api-version=2021-03-01")]
        Task<Response<AnyOf<CsmUsageQuotaCollection, DefaultErrorResponse>>> AppServicePlansListUsagesAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Query(Name = "$filter")] string filter);

        /// <summary>
        /// Get all Virtual Networks associated with an App Service plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections?api-version=2021-03-01")]
        Task<Response<AnyOf<VnetInfoResource[], DefaultErrorResponse>>> AppServicePlansListVnetsAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name);

        /// <summary>
        /// Get a Virtual Network associated with an App Service plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        /// <param name="vnetName">Name of the Virtual Network.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}?api-version=2021-03-01")]
        Task<Response<AnyOf<VnetInfoResource, object, DefaultErrorResponse>>> AppServicePlansGetVnetFromServerFarmAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Path] string vnetName);

        /// <summary>
        /// Get a Virtual Network gateway.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        /// <param name="vnetName">Name of the Virtual Network.</param>
        /// <param name="gatewayName">Name of the gateway. Only the 'primary' gateway is supported.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}/gateways/{gatewayName}?api-version=2021-03-01")]
        Task<Response<AnyOf<VnetGateway, DefaultErrorResponse>>> AppServicePlansGetVnetGatewayAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Path] string vnetName, [Path] string gatewayName);

        /// <summary>
        /// Update a Virtual Network gateway.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        /// <param name="vnetName">Name of the Virtual Network.</param>
        /// <param name="gatewayName">Name of the gateway. Only the 'primary' gateway is supported.</param>
        /// <param name="content">Definition of the gateway.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}/gateways/{gatewayName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<VnetGateway, DefaultErrorResponse>>> AppServicePlansUpdateVnetGatewayAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Path] string vnetName, [Path] string gatewayName, [Body] VnetGateway content);

        /// <summary>
        /// Get all routes that are associated with a Virtual Network in an App Service plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        /// <param name="vnetName">Name of the Virtual Network.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}/routes?api-version=2021-03-01")]
        Task<Response<AnyOf<VnetRoute[], DefaultErrorResponse>>> AppServicePlansListRoutesForVnetAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Path] string vnetName);

        /// <summary>
        /// Get a Virtual Network route in an App Service plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        /// <param name="vnetName">Name of the Virtual Network.</param>
        /// <param name="routeName">Name of the Virtual Network route.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}/routes/{routeName}?api-version=2021-03-01")]
        Task<Response<AnyOf<VnetRoute[], object, DefaultErrorResponse>>> AppServicePlansGetRouteForVnetAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Path] string vnetName, [Path] string routeName);

        /// <summary>
        /// Create or update a Virtual Network route in an App Service plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        /// <param name="vnetName">Name of the Virtual Network.</param>
        /// <param name="routeName">Name of the Virtual Network route.</param>
        /// <param name="content">Definition of the Virtual Network route.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}/routes/{routeName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<VnetRoute, object, DefaultErrorResponse>>> AppServicePlansCreateOrUpdateVnetRouteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Path] string vnetName, [Path] string routeName, [Body] VnetRoute content);

        /// <summary>
        /// Delete a Virtual Network route in an App Service plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        /// <param name="vnetName">Name of the Virtual Network.</param>
        /// <param name="routeName">Name of the Virtual Network route.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}/routes/{routeName}?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> AppServicePlansDeleteVnetRouteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Path] string vnetName, [Path] string routeName);

        /// <summary>
        /// Create or update a Virtual Network route in an App Service plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        /// <param name="vnetName">Name of the Virtual Network.</param>
        /// <param name="routeName">Name of the Virtual Network route.</param>
        /// <param name="content">Definition of the Virtual Network route.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}/routes/{routeName}?api-version=2021-03-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<VnetRoute, object, DefaultErrorResponse>>> AppServicePlansUpdateVnetRouteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Path] string vnetName, [Path] string routeName, [Body] VnetRoute content);

        /// <summary>
        /// Reboot a worker machine in an App Service plan.
        /// </summary>
        /// <param name="subscriptionId">Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).</param>
        /// <param name="resourceGroupName">Name of the resource group to which the resource belongs.</param>
        /// <param name="name">Name of the App Service plan.</param>
        /// <param name="workerName">Name of worker machine, which typically starts with RD.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/workers/{workerName}/reboot?api-version=2021-03-01")]
        Task<Response<AnyOf<object, DefaultErrorResponse>>> AppServicePlansRebootWorkerAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string name, [Path] string workerName);
    }
}