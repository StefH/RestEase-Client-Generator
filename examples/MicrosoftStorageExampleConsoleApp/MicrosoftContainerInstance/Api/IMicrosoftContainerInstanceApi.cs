using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnyOfTypes;
using RestEase;
using MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Api
{
    /// <summary>
    /// MicrosoftContainerInstance
    /// </summary>
    public interface IMicrosoftContainerInstanceApi
    {
        /// <summary>
        /// Get a list of container groups in the specified subscription.
        ///
        /// ContainerGroupsList (/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/containerGroups)
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/containerGroups?api-version=2021-10-01")]
        Task<Response<AnyOf<ContainerGroupListResult, CloudError>>> ContainerGroupsListAsync([Path] string subscriptionId);

        /// <summary>
        /// Get a list of container groups in the specified subscription and resource group.
        ///
        /// ContainerGroupsListByResourceGroup (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups)
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups?api-version=2021-10-01")]
        Task<Response<AnyOf<ContainerGroupListResult, CloudError>>> ContainerGroupsListByResourceGroupAsync([Path] string subscriptionId, [Path] string resourceGroupName);

        /// <summary>
        /// Get the properties of the specified container group.
        ///
        /// ContainerGroupsGet (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName})
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}?api-version=2021-10-01")]
        Task<Response<AnyOf<ContainerGroup, CloudError>>> ContainerGroupsGetAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);

        /// <summary>
        /// Create or update container groups.
        ///
        /// ContainerGroupsCreateOrUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName})
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        /// <param name="content">A container group.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}?api-version=2021-10-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ContainerGroup, CloudError>>> ContainerGroupsCreateOrUpdateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName, [Body] ContainerGroup content);

        /// <summary>
        /// Update container groups.
        ///
        /// ContainerGroupsUpdate (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName})
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        /// <param name="content">The Resource model definition.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}?api-version=2021-10-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ContainerGroup, CloudError>>> ContainerGroupsUpdateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName, [Body] Resource content);

        /// <summary>
        /// Delete the specified container group.
        ///
        /// ContainerGroupsDelete (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName})
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}?api-version=2021-10-01")]
        Task<Response<AnyOf<ContainerGroup, object, CloudError>>> ContainerGroupsDeleteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);

        /// <summary>
        /// Restarts all containers in a container group.
        ///
        /// ContainerGroupsRestart (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/restart)
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/restart?api-version=2021-10-01")]
        Task<Response<AnyOf<object, CloudError>>> ContainerGroupsRestartAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);

        /// <summary>
        /// Stops all containers in a container group.
        ///
        /// ContainerGroupsStop (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/stop)
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/stop?api-version=2021-10-01")]
        Task<Response<AnyOf<object, CloudError>>> ContainerGroupsStopAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);

        /// <summary>
        /// Starts all containers in a container group.
        ///
        /// ContainerGroupsStart (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/start)
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/start?api-version=2021-10-01")]
        Task<Response<AnyOf<object, CloudError>>> ContainerGroupsStartAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);

        /// <summary>
        /// List the operations for Azure Container Instance service.
        ///
        /// OperationsList (/providers/Microsoft.ContainerInstance/operations)
        /// </summary>
        [Get("/providers/Microsoft.ContainerInstance/operations?api-version=2021-10-01")]
        Task<Response<AnyOf<OperationListResult, CloudError>>> OperationsListAsync();

        /// <summary>
        /// Get the usage for a subscription
        ///
        /// LocationListUsage (/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/locations/{location}/usages)
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="location">The identifier for the physical azure location.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/locations/{location}/usages?api-version=2021-10-01")]
        Task<Response<AnyOf<UsageListResult, CloudError>>> LocationListUsageAsync([Path] string subscriptionId, [Path] string location);

        /// <summary>
        /// Get the logs for a specified container instance.
        ///
        /// ContainersListLogs (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/containers/{containerName}/logs)
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        /// <param name="containerName">The name of the container instance.</param>
        /// <param name="tail">The number of lines to show from the tail of the container instance log. If not provided, all available logs are shown up to 4mb.</param>
        /// <param name="timestamps">If true, adds a timestamp at the beginning of every line of log output. If not provided, defaults to false.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/containers/{containerName}/logs?api-version=2021-10-01")]
        Task<Response<AnyOf<Logs, CloudError>>> ContainersListLogsAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName, [Path] string containerName, [Query] int? tail, [Query] bool? timestamps);

        /// <summary>
        /// Executes a command in a specific container instance.
        ///
        /// ContainersExecuteCommand (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/containers/{containerName}/exec)
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        /// <param name="containerName">The name of the container instance.</param>
        /// <param name="content">The container exec request.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/containers/{containerName}/exec?api-version=2021-10-01")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ContainerExecResponse, CloudError>>> ContainersExecuteCommandAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName, [Path] string containerName, [Body] ContainerExecRequest content);

        /// <summary>
        /// Attach to the output of a specific container instance.
        ///
        /// ContainersAttach (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/containers/{containerName}/attach)
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        /// <param name="containerName">The name of the container instance.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/containers/{containerName}/attach?api-version=2021-10-01")]
        Task<Response<AnyOf<ContainerAttachResponse, CloudError>>> ContainersAttachAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName, [Path] string containerName);

        /// <summary>
        /// Get the list of cached images.
        ///
        /// LocationListCachedImages (/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/locations/{location}/cachedImages)
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="location">The identifier for the physical azure location.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/locations/{location}/cachedImages?api-version=2021-10-01")]
        Task<Response<AnyOf<CachedImagesListResult, CloudError>>> LocationListCachedImagesAsync([Path] string subscriptionId, [Path] string location);

        /// <summary>
        /// Get the list of capabilities of the location.
        ///
        /// LocationListCapabilities (/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/locations/{location}/capabilities)
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="location">The identifier for the physical azure location.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/locations/{location}/capabilities?api-version=2021-10-01")]
        Task<Response<AnyOf<CapabilitiesListResult, CloudError>>> LocationListCapabilitiesAsync([Path] string subscriptionId, [Path] string location);

        /// <summary>
        /// Get all network dependencies for container group.
        ///
        /// ContainerGroupsGetOutboundNetworkDependenciesEndpoints (/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/outboundNetworkDependenciesEndpoints)
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/outboundNetworkDependenciesEndpoints?api-version=2021-10-01")]
        Task<Response<AnyOf<string[], CloudError>>> ContainerGroupsGetOutboundNetworkDependenciesEndpointsAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);
    }
}