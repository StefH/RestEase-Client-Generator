using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnyOfTypes;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Api
{
    /// <summary>
    /// MicrosoftContainerInstance
    /// </summary>
    public interface IMicrosoftContainerInstanceApi
    {
        [Query("Azure Active Directory OAuth2 Flow")]
        string AzureActiveDirectoryOAuth2Flow { get; set; }

        [Query("api-version")]
        string ApiVersion { get; set; }

        /// <summary>
        /// Get a list of container groups in the specified subscription.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/containerGroups")]
        Task<AnyOf<ContainerGroupListResult, CloudError>> ContainerGroupsListAsync([Path] string subscriptionId);

        /// <summary>
        /// Get a list of container groups in the specified subscription and resource group.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups")]
        Task<AnyOf<ContainerGroupListResult, CloudError>> ContainerGroupsListByResourceGroupAsync([Path] string subscriptionId, [Path] string resourceGroupName);

        /// <summary>
        /// Get the properties of the specified container group.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}")]
        Task<AnyOf<ContainerGroup, CloudError>> ContainerGroupsGetAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);

        /// <summary>
        /// Create or update container groups.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}")]
        [Header("Content-Type", "application/json")]
        Task<AnyOf<ContainerGroup, ContainerGroup, CloudError>> ContainerGroupsCreateOrUpdateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);

        /// <summary>
        /// Update container groups.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        /// <param name="content">The Resource model definition.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}")]
        [Header("Content-Type", "application/json")]
        Task<AnyOf<ContainerGroup, CloudError>> ContainerGroupsUpdateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName, [Body] Resource content);

        /// <summary>
        /// Delete the specified container group.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}")]
        Task<AnyOf<ContainerGroup, object, object, CloudError>> ContainerGroupsDeleteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);

        /// <summary>
        /// Restarts all containers in a container group.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/restart")]
        Task<AnyOf<object, CloudError>> ContainerGroupsRestartAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);

        /// <summary>
        /// Stops all containers in a container group.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/stop")]
        Task<AnyOf<object, CloudError>> ContainerGroupsStopAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);

        /// <summary>
        /// Starts all containers in a container group.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/start")]
        Task<AnyOf<object, CloudError>> ContainerGroupsStartAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);

        /// <summary>
        /// OperationsList (/providers/Microsoft.ContainerInstance/operations)
        /// </summary>
        [Get("/providers/Microsoft.ContainerInstance/operations")]
        Task<AnyOf<OperationListResult, CloudError>> OperationsListAsync();

        /// <summary>
        /// LocationListUsage (/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/locations/{location}/usages)
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="location">The identifier for the physical azure location.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/locations/{location}/usages")]
        Task<AnyOf<UsageListResult, CloudError>> LocationListUsageAsync([Path] string subscriptionId, [Path] string location);

        /// <summary>
        /// Get the logs for a specified container instance.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        /// <param name="containerName">The name of the container instance.</param>
        /// <param name="tail">The number of lines to show from the tail of the container instance log. If not provided, all available logs are shown up to 4mb.</param>
        /// <param name="timestamps">If true, adds a timestamp at the beginning of every line of log output. If not provided, defaults to false.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/containers/{containerName}/logs")]
        Task<AnyOf<Logs, CloudError>> ContainersListLogsAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName, [Path] string containerName, [Query] int? tail, [Query] bool? timestamps);

        /// <summary>
        /// Executes a command in a specific container instance.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        /// <param name="containerName">The name of the container instance.</param>
        /// <param name="content">The container exec request.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/containers/{containerName}/exec")]
        [Header("Content-Type", "application/json")]
        Task<AnyOf<ContainerExecResponse, CloudError>> ContainersExecuteCommandAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName, [Path] string containerName, [Body] ContainerExecRequest content);

        /// <summary>
        /// Attach to the output of a specific container instance.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        /// <param name="containerName">The name of the container instance.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/containers/{containerName}/attach")]
        Task<AnyOf<ContainerAttachResponse, CloudError>> ContainersAttachAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName, [Path] string containerName);

        /// <summary>
        /// Get the list of cached images.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="location">The identifier for the physical azure location.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/locations/{location}/cachedImages")]
        Task<AnyOf<CachedImagesListResult, CloudError>> LocationListCachedImagesAsync([Path] string subscriptionId, [Path] string location);

        /// <summary>
        /// Get the list of capabilities of the location.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="location">The identifier for the physical azure location.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/locations/{location}/capabilities")]
        Task<AnyOf<CapabilitiesListResult, CloudError>> LocationListCapabilitiesAsync([Path] string subscriptionId, [Path] string location);

        /// <summary>
        /// Get all network dependencies for container group.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/outboundNetworkDependenciesEndpoints")]
        Task<AnyOf<string[], CloudError>> ContainerGroupsGetOutboundNetworkDependenciesEndpointsAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);
    }
}
