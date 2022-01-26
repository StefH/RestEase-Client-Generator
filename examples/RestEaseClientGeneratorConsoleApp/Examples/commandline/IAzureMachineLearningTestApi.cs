using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnyOfTypes;
using RestEase;
using AzureMachineLearningTest.Models;

namespace AzureMachineLearningTest.Api
{
    /// <summary>
    /// AzureMachineLearningTest
    /// </summary>
    public interface IAzureMachineLearningTestApi
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
        Task<Response<AnyOf<ContainerGroupListResult, CloudError>>> ContainerGroupsListAsync([Path] string subscriptionId);

        /// <summary>
        /// Get a list of container groups in the specified subscription and resource group.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups")]
        Task<Response<AnyOf<ContainerGroupListResult, CloudError>>> ContainerGroupsListByResourceGroupAsync([Path] string subscriptionId, [Path] string resourceGroupName);

        /// <summary>
        /// Get the properties of the specified container group.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}")]
        Task<Response<AnyOf<ContainerGroup, CloudError>>> ContainerGroupsGetAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);

        /// <summary>
        /// Create or update container groups.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        /// <param name="content">A container group.</param>
        [Put("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ContainerGroup, CloudError>>> ContainerGroupsCreateOrUpdateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName, [Body] ContainerGroup content);

        /// <summary>
        /// Update container groups.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        /// <param name="content">The Resource model definition.</param>
        [Patch("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ContainerGroup, CloudError>>> ContainerGroupsUpdateAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName, [Body] Resource content);

        /// <summary>
        /// Delete the specified container group.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Delete("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}")]
        Task<Response<AnyOf<ContainerGroup, CloudError>>> ContainerGroupsDeleteAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);

        /// <summary>
        /// Restarts all containers in a container group.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/restart")]
        Task<CloudError> ContainerGroupsRestartAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);

        /// <summary>
        /// Stops all containers in a container group.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/stop")]
        Task<CloudError> ContainerGroupsStopAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);

        /// <summary>
        /// Starts all containers in a container group.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/start")]
        Task<CloudError> ContainerGroupsStartAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);

        /// <summary>
        /// OperationsList (/providers/Microsoft.ContainerInstance/operations)
        /// </summary>
        [Get("/providers/Microsoft.ContainerInstance/operations")]
        Task<Response<AnyOf<OperationListResult, CloudError>>> OperationsListAsync();

        /// <summary>
        /// LocationListUsage (/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/locations/{location}/usages)
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="location">The identifier for the physical azure location.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/locations/{location}/usages")]
        Task<Response<AnyOf<UsageListResult, CloudError>>> LocationListUsageAsync([Path] string subscriptionId, [Path] string location);

        /// <summary>
        /// Get the logs for a specified container instance.
        /// </summary>
        /// <param name="containerName">The name of the container instance.</param>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        /// <param name="tail">The number of lines to show from the tail of the container instance log. If not provided, all available logs are shown up to 4mb.</param>
        /// <param name="timestamps">If true, adds a timestamp at the beginning of every line of log output. If not provided, defaults to false.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/containers/{containerName}/logs")]
        Task<Response<AnyOf<Logs, CloudError>>> ContainersListLogsAsync([Path] string containerName, [Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName, [Query] int? tail, [Query] bool? timestamps);

        /// <summary>
        /// Executes a command in a specific container instance.
        /// </summary>
        /// <param name="containerName">The name of the container instance.</param>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        /// <param name="content">The container exec request.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/containers/{containerName}/exec")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ContainerExecResponse, CloudError>>> ContainersExecuteCommandAsync([Path] string containerName, [Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName, [Body] ContainerExecRequest content);

        /// <summary>
        /// Attach to the output of a specific container instance.
        /// </summary>
        /// <param name="containerName">The name of the container instance.</param>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Post("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/containers/{containerName}/attach")]
        Task<Response<AnyOf<ContainerAttachResponse, CloudError>>> ContainersAttachAsync([Path] string containerName, [Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);

        /// <summary>
        /// Get the list of cached images.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="location">The identifier for the physical azure location.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/locations/{location}/cachedImages")]
        Task<Response<AnyOf<CachedImagesListResult, CloudError>>> LocationListCachedImagesAsync([Path] string subscriptionId, [Path] string location);

        /// <summary>
        /// Get the list of capabilities of the location.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="location">The identifier for the physical azure location.</param>
        [Get("/subscriptions/{subscriptionId}/providers/Microsoft.ContainerInstance/locations/{location}/capabilities")]
        Task<Response<AnyOf<CapabilitiesListResult, CloudError>>> LocationListCapabilitiesAsync([Path] string subscriptionId, [Path] string location);

        /// <summary>
        /// Get all network dependencies for container group.
        /// </summary>
        /// <param name="subscriptionId">Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.</param>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="containerGroupName">The name of the container group.</param>
        [Get("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/outboundNetworkDependenciesEndpoints")]
        Task<Response<AnyOf<string[], CloudError>>> ContainerGroupsGetOutboundNetworkDependenciesEndpointsAsync([Path] string subscriptionId, [Path] string resourceGroupName, [Path] string containerGroupName);
    }
}
namespace AzureMachineLearningTest.Models
{
    /// <summary>
    /// The properties of the Azure File volume. Azure File shares are mounted as volumes.
    /// </summary>
    public class AzureFileVolume
    {
        /// <summary>
        /// The name of the Azure File share to be mounted as a volume.
        /// </summary>
        public string ShareName { get; set; }

        /// <summary>
        /// The flag indicating whether the Azure File shared mounted as a volume is read-only.
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// The name of the storage account that contains the Azure File share.
        /// </summary>
        public string StorageAccountName { get; set; }

        /// <summary>
        /// The storage account access key used to access the Azure File share.
        /// </summary>
        public string StorageAccountKey { get; set; }
    }

    /// <summary>
    /// The cached image and OS type.
    /// </summary>
    public class CachedImages
    {
        /// <summary>
        /// The OS type of the cached image.
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        /// The cached image name.
        /// </summary>
        public string Image { get; set; }
    }

    /// <summary>
    /// The response containing cached images.
    /// </summary>
    public class CachedImagesListResult
    {
        /// <summary>
        /// The list of cached images.
        /// </summary>
        public CachedImages[] Value { get; set; }

        /// <summary>
        /// The URI to fetch the next page of cached images.
        /// </summary>
        public string NextLink { get; set; }
    }

    /// <summary>
    /// The regional capabilities.
    /// </summary>
    public class Capabilities
    {
        /// <summary>
        /// The resource type that this capability describes.
        /// </summary>
        public string ResourceType { get; set; }

        /// <summary>
        /// The OS type that this capability describes.
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        /// The resource location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The ip address type that this capability describes.
        /// </summary>
        public string IpAddressType { get; set; }

        /// <summary>
        /// The GPU sku that this capability describes.
        /// </summary>
        public string Gpu { get; set; }

        /// <summary>
        /// The supported capabilities.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Capabilities")]
        public CapabilitiesCapabilities Capabilities_ { get; set; }
    }

    /// <summary>
    /// The supported capabilities.
    /// </summary>
    public class CapabilitiesCapabilities
    {
        /// <summary>
        /// The maximum allowed memory request in GB.
        /// </summary>
        public double MaxMemoryInGB { get; set; }

        /// <summary>
        /// The maximum allowed CPU request in cores.
        /// </summary>
        public double MaxCpu { get; set; }

        /// <summary>
        /// The maximum allowed GPU count.
        /// </summary>
        public double MaxGpuCount { get; set; }
    }

    /// <summary>
    /// The response containing list of capabilities.
    /// </summary>
    public class CapabilitiesListResult
    {
        /// <summary>
        /// The list of capabilities.
        /// </summary>
        public Capabilities[] Value { get; set; }

        /// <summary>
        /// The URI to fetch the next page of capabilities.
        /// </summary>
        public string NextLink { get; set; }
    }

    /// <summary>
    /// An error response from the Container Instance service.
    /// </summary>
    public class CloudError
    {
        /// <summary>
        /// An error response from the Container Instance service.
        /// </summary>
        public CloudErrorBody Error { get; set; }
    }

    /// <summary>
    /// An error response from the Container Instance service.
    /// </summary>
    public class CloudErrorBody
    {
        /// <summary>
        /// An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// A message describing the error, intended to be suitable for display in a user interface.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The target of the particular error. For example, the name of the property in error.
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// A list of additional details about the error.
        /// </summary>
        public CloudErrorBody[] Details { get; set; }
    }

    /// <summary>
    /// A container instance.
    /// </summary>
    public class Container
    {
        /// <summary>
        /// The user-provided name of the container instance.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The container instance properties.
        /// </summary>
        public ContainerProperties Properties { get; set; }
    }

    /// <summary>
    /// The information for the output stream from container attach.
    /// </summary>
    public class ContainerAttachResponse
    {
        /// <summary>
        /// The uri for the output stream from the attach.
        /// </summary>
        public string WebSocketUri { get; set; }

        /// <summary>
        /// The password to the output stream from the attach. Send as an Authorization header value when connecting to the websocketUri.
        /// </summary>
        public string Password { get; set; }
    }

    /// <summary>
    /// The container execution command, for liveness or readiness probe
    /// </summary>
    public class ContainerExec
    {
        /// <summary>
        /// The commands to execute within the container.
        /// </summary>
        public string[] Command { get; set; }
    }

    /// <summary>
    /// The container exec request.
    /// </summary>
    public class ContainerExecRequest
    {
        /// <summary>
        /// The command to be executed.
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// The size of the terminal.
        /// </summary>
        public ContainerExecRequestTerminalSize TerminalSize { get; set; }
    }

    /// <summary>
    /// The size of the terminal.
    /// </summary>
    public class ContainerExecRequestTerminalSize
    {
        /// <summary>
        /// The row size of the terminal
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// The column size of the terminal
        /// </summary>
        public int Cols { get; set; }
    }

    /// <summary>
    /// The information for the container exec command.
    /// </summary>
    public class ContainerExecResponse
    {
        /// <summary>
        /// The uri for the exec websocket.
        /// </summary>
        public string WebSocketUri { get; set; }

        /// <summary>
        /// The password to start the exec command.
        /// </summary>
        public string Password { get; set; }
    }

    /// <summary>
    /// A container group.
    /// </summary>
    public class ContainerGroup : Resource
    {
        /// <summary>
        /// Identity for the container group.
        /// </summary>
        public ContainerGroupIdentity Identity { get; set; }

        /// <summary>
        /// The container group properties
        /// </summary>
        public ContainerGroupProperties Properties { get; set; }
    }

    /// <summary>
    /// Container group diagnostic information.
    /// </summary>
    public class ContainerGroupDiagnostics
    {
        /// <summary>
        /// Container group log analytics information.
        /// </summary>
        public LogAnalytics LogAnalytics { get; set; }
    }

    /// <summary>
    /// Identity for the container group.
    /// </summary>
    public class ContainerGroupIdentity
    {
        /// <summary>
        /// The principal id of the container group identity. This property will only be provided for a system assigned identity.
        /// </summary>
        public string PrincipalId { get; set; }

        /// <summary>
        /// The tenant id associated with the container group. This property will only be provided for a system assigned identity.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The type of identity used for the container group. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities. The type 'None' will remove any identities from the container group.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The list of user identities associated with the container group. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        public Dictionary<string, ContainerGroupIdentityUserAssignedIdentities> ContainerGroupIdentityUserAssignedIdentities { get; set; }
    }

    public class ContainerGroupIdentityUserAssignedIdentities
    {
        /// <summary>
        /// The principal id of user assigned identity.
        /// </summary>
        public string PrincipalId { get; set; }

        /// <summary>
        /// The client id of user assigned identity.
        /// </summary>
        public string ClientId { get; set; }
    }

    /// <summary>
    /// The container group list response that contains the container group properties.
    /// </summary>
    public class ContainerGroupListResult
    {
        /// <summary>
        /// The list of container groups.
        /// </summary>
        public ContainerGroup[] Value { get; set; }

        /// <summary>
        /// The URI to fetch the next page of container groups.
        /// </summary>
        public string NextLink { get; set; }
    }

    /// <summary>
    /// The container group properties
    /// </summary>
    public class ContainerGroupProperties
    {
        /// <summary>
        /// The provisioning state of the container group. This only appears in the response.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// The containers within the container group.
        /// </summary>
        public Container[] Containers { get; set; }

        /// <summary>
        /// The image registry credentials by which the container group is created from.
        /// </summary>
        public ImageRegistryCredential[] ImageRegistryCredentials { get; set; }

        /// <summary>
        /// Restart policy for all containers within the container group. - `Always` Always restart- `OnFailure` Restart on failure- `Never` Never restart
        /// </summary>
        public string RestartPolicy { get; set; }

        /// <summary>
        /// IP address for the container group.
        /// </summary>
        public IpAddress IpAddress { get; set; }

        /// <summary>
        /// The operating system type required by the containers in the container group.
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        /// The list of volumes that can be mounted by containers in this container group.
        /// </summary>
        public Volume[] Volumes { get; set; }

        /// <summary>
        /// The instance view of the container group. Only valid in response.
        /// </summary>
        public ContainerGroupPropertiesInstanceView InstanceView { get; set; }

        /// <summary>
        /// Container group diagnostic information.
        /// </summary>
        public ContainerGroupDiagnostics Diagnostics { get; set; }

        /// <summary>
        /// The subnet resource IDs for a container group.
        /// </summary>
        public ContainerGroupSubnetId[] SubnetIds { get; set; }

        /// <summary>
        /// DNS configuration for the container group.
        /// </summary>
        public DnsConfiguration DnsConfig { get; set; }

        /// <summary>
        /// The container group SKU.
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// The container group encryption properties.
        /// </summary>
        public EncryptionProperties EncryptionProperties { get; set; }

        /// <summary>
        /// The init containers for a container group.
        /// </summary>
        public InitContainerDefinition[] InitContainers { get; set; }
    }

    /// <summary>
    /// The instance view of the container group. Only valid in response.
    /// </summary>
    public class ContainerGroupPropertiesInstanceView
    {
        /// <summary>
        /// The events of this container group.
        /// </summary>
        public Event[] Events { get; set; }

        /// <summary>
        /// The state of the container group. Only valid in response.
        /// </summary>
        public string State { get; set; }
    }

    /// <summary>
    /// Container group subnet information.
    /// </summary>
    public class ContainerGroupSubnetId
    {
        /// <summary>
        /// Resource ID of virtual network and subnet.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Friendly name for the subnet.
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// The container Http Get settings, for liveness or readiness probe
    /// </summary>
    public class ContainerHttpGet
    {
        /// <summary>
        /// The path to probe.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The port number to probe.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The scheme.
        /// </summary>
        public string Scheme { get; set; }

        /// <summary>
        /// The HTTP headers.
        /// </summary>
        public HttpHeader[] HttpHeaders { get; set; }
    }

    /// <summary>
    /// The port exposed on the container instance.
    /// </summary>
    public class ContainerPort
    {
        /// <summary>
        /// The protocol associated with the port.
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// The port number exposed within the container group.
        /// </summary>
        public int Port { get; set; }
    }

    /// <summary>
    /// The container probe, for liveness or readiness
    /// </summary>
    public class ContainerProbe
    {
        /// <summary>
        /// The container execution command, for liveness or readiness probe
        /// </summary>
        public ContainerExec Exec { get; set; }

        /// <summary>
        /// The container Http Get settings, for liveness or readiness probe
        /// </summary>
        public ContainerHttpGet HttpGet { get; set; }

        /// <summary>
        /// The initial delay seconds.
        /// </summary>
        public int InitialDelaySeconds { get; set; }

        /// <summary>
        /// The period seconds.
        /// </summary>
        public int PeriodSeconds { get; set; }

        /// <summary>
        /// The failure threshold.
        /// </summary>
        public int FailureThreshold { get; set; }

        /// <summary>
        /// The success threshold.
        /// </summary>
        public int SuccessThreshold { get; set; }

        /// <summary>
        /// The timeout seconds.
        /// </summary>
        public int TimeoutSeconds { get; set; }
    }

    /// <summary>
    /// The container instance properties.
    /// </summary>
    public class ContainerProperties
    {
        /// <summary>
        /// The name of the image used to create the container instance.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// The commands to execute within the container instance in exec form.
        /// </summary>
        public string[] Command { get; set; }

        /// <summary>
        /// The exposed ports on the container instance.
        /// </summary>
        public ContainerPort[] Ports { get; set; }

        /// <summary>
        /// The environment variables to set in the container instance.
        /// </summary>
        public EnvironmentVariable[] EnvironmentVariables { get; set; }

        /// <summary>
        /// The instance view of the container instance. Only valid in response.
        /// </summary>
        public ContainerPropertiesInstanceView InstanceView { get; set; }

        /// <summary>
        /// The resource requirements.
        /// </summary>
        public ResourceRequirements Resources { get; set; }

        /// <summary>
        /// The volume mounts available to the container instance.
        /// </summary>
        public VolumeMount[] VolumeMounts { get; set; }

        /// <summary>
        /// The container probe, for liveness or readiness
        /// </summary>
        public ContainerProbe LivenessProbe { get; set; }

        /// <summary>
        /// The container probe, for liveness or readiness
        /// </summary>
        public ContainerProbe ReadinessProbe { get; set; }
    }

    /// <summary>
    /// The instance view of the container instance. Only valid in response.
    /// </summary>
    public class ContainerPropertiesInstanceView
    {
        /// <summary>
        /// The number of times that the container instance has been restarted.
        /// </summary>
        public int RestartCount { get; set; }

        /// <summary>
        /// The container instance state.
        /// </summary>
        public ContainerState CurrentState { get; set; }

        /// <summary>
        /// The container instance state.
        /// </summary>
        public ContainerState PreviousState { get; set; }

        /// <summary>
        /// The events of the container instance.
        /// </summary>
        public Event[] Events { get; set; }
    }

    /// <summary>
    /// The container instance state.
    /// </summary>
    public class ContainerState
    {
        /// <summary>
        /// The state of the container instance.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The date-time when the container instance state started.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The container instance exit codes correspond to those from the `docker run` command.
        /// </summary>
        public int ExitCode { get; set; }

        /// <summary>
        /// The date-time when the container instance state finished.
        /// </summary>
        public DateTime FinishTime { get; set; }

        /// <summary>
        /// The human-readable status of the container instance state.
        /// </summary>
        public string DetailStatus { get; set; }
    }

    /// <summary>
    /// DNS configuration for the container group.
    /// </summary>
    public class DnsConfiguration
    {
        /// <summary>
        /// The DNS servers for the container group.
        /// </summary>
        public string[] NameServers { get; set; }

        /// <summary>
        /// The DNS search domains for hostname lookup in the container group.
        /// </summary>
        public string SearchDomains { get; set; }

        /// <summary>
        /// The DNS options for the container group.
        /// </summary>
        public string Options { get; set; }
    }

    /// <summary>
    /// The empty directory volume.
    /// </summary>
    public class EmptyDirVolume
    {
    }

    /// <summary>
    /// The container group encryption properties.
    /// </summary>
    public class EncryptionProperties
    {
        /// <summary>
        /// The keyvault base url.
        /// </summary>
        public string VaultBaseUrl { get; set; }

        /// <summary>
        /// The encryption key name.
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// The encryption key version.
        /// </summary>
        public string KeyVersion { get; set; }
    }

    /// <summary>
    /// The environment variable to set within the container instance.
    /// </summary>
    public class EnvironmentVariable
    {
        /// <summary>
        /// The name of the environment variable.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value of the environment variable.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The value of the secure environment variable.
        /// </summary>
        public string SecureValue { get; set; }
    }

    /// <summary>
    /// A container group or container instance event.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// The count of the event.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The date-time of the earliest logged event.
        /// </summary>
        public DateTime FirstTimestamp { get; set; }

        /// <summary>
        /// The date-time of the latest logged event.
        /// </summary>
        public DateTime LastTimestamp { get; set; }

        /// <summary>
        /// The event name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The event message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The event type.
        /// </summary>
        public string Type { get; set; }
    }

    /// <summary>
    /// Represents a volume that is populated with the contents of a git repository
    /// </summary>
    public class GitRepoVolume
    {
        /// <summary>
        /// Target directory name. Must not contain or start with '..'.  If '.' is supplied, the volume directory will be the git repository.  Otherwise, if specified, the volume will contain the git repository in the subdirectory with the given name.
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// Repository URL
        /// </summary>
        public string Repository { get; set; }

        /// <summary>
        /// Commit hash for the specified revision.
        /// </summary>
        public string Revision { get; set; }
    }

    /// <summary>
    /// The GPU resource.
    /// </summary>
    public class GpuResource
    {
        /// <summary>
        /// The count of the GPU resource.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The SKU of the GPU resource.
        /// </summary>
        public string Sku { get; set; }
    }

    /// <summary>
    /// The HTTP header.
    /// </summary>
    public class HttpHeader
    {
        /// <summary>
        /// The header name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The header value.
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    /// Image registry credential.
    /// </summary>
    public class ImageRegistryCredential
    {
        /// <summary>
        /// The Docker image registry server without a protocol such as "http" and "https".
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// The username for the private registry.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password for the private registry.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The identity for the private registry.
        /// </summary>
        public string Identity { get; set; }

        /// <summary>
        /// The identity URL for the private registry.
        /// </summary>
        public string IdentityUrl { get; set; }
    }

    /// <summary>
    /// The init container definition.
    /// </summary>
    public class InitContainerDefinition
    {
        /// <summary>
        /// The name for the init container.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The init container definition properties.
        /// </summary>
        public InitContainerPropertiesDefinition Properties { get; set; }
    }

    /// <summary>
    /// The init container definition properties.
    /// </summary>
    public class InitContainerPropertiesDefinition
    {
        /// <summary>
        /// The image of the init container.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// The command to execute within the init container in exec form.
        /// </summary>
        public string[] Command { get; set; }

        /// <summary>
        /// The environment variables to set in the init container.
        /// </summary>
        public EnvironmentVariable[] EnvironmentVariables { get; set; }

        /// <summary>
        /// The instance view of the init container. Only valid in response.
        /// </summary>
        public InitContainerPropertiesDefinitionInstanceView InstanceView { get; set; }

        /// <summary>
        /// The volume mounts available to the init container.
        /// </summary>
        public VolumeMount[] VolumeMounts { get; set; }
    }

    /// <summary>
    /// The instance view of the init container. Only valid in response.
    /// </summary>
    public class InitContainerPropertiesDefinitionInstanceView
    {
        /// <summary>
        /// The number of times that the init container has been restarted.
        /// </summary>
        public int RestartCount { get; set; }

        /// <summary>
        /// The container instance state.
        /// </summary>
        public ContainerState CurrentState { get; set; }

        /// <summary>
        /// The container instance state.
        /// </summary>
        public ContainerState PreviousState { get; set; }

        /// <summary>
        /// The events of the init container.
        /// </summary>
        public Event[] Events { get; set; }
    }

    /// <summary>
    /// IP address for the container group.
    /// </summary>
    public class IpAddress
    {
        /// <summary>
        /// The list of ports exposed on the container group.
        /// </summary>
        public Port[] Ports { get; set; }

        /// <summary>
        /// Specifies if the IP is exposed to the public internet or private VNET.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The IP exposed to the public internet.
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// The Dns name label for the IP.
        /// </summary>
        public string DnsNameLabel { get; set; }

        /// <summary>
        /// The value representing the security enum.
        /// </summary>
        public string DnsNameLabelReusePolicy { get; set; }

        /// <summary>
        /// The FQDN for the IP.
        /// </summary>
        public string Fqdn { get; set; }
    }

    /// <summary>
    /// Container group log analytics information.
    /// </summary>
    public class LogAnalytics
    {
        /// <summary>
        /// The workspace id for log analytics
        /// </summary>
        public string WorkspaceId { get; set; }

        /// <summary>
        /// The workspace key for log analytics
        /// </summary>
        public string WorkspaceKey { get; set; }

        /// <summary>
        /// The log type to be used.
        /// </summary>
        public string LogType { get; set; }

        /// <summary>
        /// Metadata for log analytics.
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// The workspace resource id for log analytics
        /// </summary>
        public string WorkspaceResourceId { get; set; }
    }

    /// <summary>
    /// The logs.
    /// </summary>
    public class Logs
    {
        /// <summary>
        /// The content of the log.
        /// </summary>
        public string Content { get; set; }
    }

    /// <summary>
    /// An operation for Azure Container Instance service.
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// The name of the operation.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The display information of the operation.
        /// </summary>
        public OperationDisplay Display { get; set; }

        /// <summary>
        /// The additional properties.
        /// </summary>
        public OperationProperties Properties { get; set; }

        /// <summary>
        /// The intended executor of the operation.
        /// </summary>
        public string Origin { get; set; }
    }

    /// <summary>
    /// The display information of the operation.
    /// </summary>
    public class OperationDisplay
    {
        /// <summary>
        /// The name of the provider of the operation.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// The name of the resource type of the operation.
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// The friendly name of the operation.
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// The description of the operation.
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// The operation list response that contains all operations for Azure Container Instance service.
    /// </summary>
    public class OperationListResult
    {
        /// <summary>
        /// The list of operations.
        /// </summary>
        public Operation[] Value { get; set; }

        /// <summary>
        /// The URI to fetch the next page of operations.
        /// </summary>
        public string NextLink { get; set; }
    }

    /// <summary>
    /// The additional properties.
    /// </summary>
    public class OperationProperties
    {
    }

    /// <summary>
    /// The port exposed on the container group.
    /// </summary>
    public class Port
    {
        /// <summary>
        /// The protocol associated with the port.
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// The port number.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Port")]
        public int Port_ { get; set; }
    }

    /// <summary>
    /// The Resource model definition.
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// The resource id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The resource name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The resource type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The resource location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The resource tags.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// The zones for the container group.
        /// </summary>
        public string[] Zones { get; set; }
    }

    /// <summary>
    /// The resource limits.
    /// </summary>
    public class ResourceLimits
    {
        /// <summary>
        /// The memory limit in GB of this container instance.
        /// </summary>
        public double MemoryInGB { get; set; }

        /// <summary>
        /// The CPU limit of this container instance.
        /// </summary>
        public double Cpu { get; set; }

        /// <summary>
        /// The GPU resource.
        /// </summary>
        public GpuResource Gpu { get; set; }
    }

    /// <summary>
    /// The resource requests.
    /// </summary>
    public class ResourceRequests
    {
        /// <summary>
        /// The memory request in GB of this container instance.
        /// </summary>
        public double MemoryInGB { get; set; }

        /// <summary>
        /// The CPU request of this container instance.
        /// </summary>
        public double Cpu { get; set; }

        /// <summary>
        /// The GPU resource.
        /// </summary>
        public GpuResource Gpu { get; set; }
    }

    /// <summary>
    /// The resource requirements.
    /// </summary>
    public class ResourceRequirements
    {
        /// <summary>
        /// The resource requests.
        /// </summary>
        public ResourceRequests Requests { get; set; }

        /// <summary>
        /// The resource limits.
        /// </summary>
        public ResourceLimits Limits { get; set; }
    }

    /// <summary>
    /// A single usage result
    /// </summary>
    public class Usage
    {
        /// <summary>
        /// Unit of the usage result
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// The current usage of the resource
        /// </summary>
        public int CurrentValue { get; set; }

        /// <summary>
        /// The maximum permitted usage of the resource.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// The name object of the resource
        /// </summary>
        public UsageName Name { get; set; }
    }

    /// <summary>
    /// The response containing the usage data
    /// </summary>
    public class UsageListResult
    {
        /// <summary>
        /// The usage data.
        /// </summary>
        public Usage[] Value { get; set; }
    }

    /// <summary>
    /// The name object of the resource
    /// </summary>
    public class UsageName
    {
        /// <summary>
        /// The name of the resource
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The localized name of the resource
        /// </summary>
        public string LocalizedValue { get; set; }
    }

    /// <summary>
    /// The properties of the volume.
    /// </summary>
    public class Volume
    {
        /// <summary>
        /// The name of the volume.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The properties of the Azure File volume. Azure File shares are mounted as volumes.
        /// </summary>
        public AzureFileVolume AzureFile { get; set; }

        /// <summary>
        /// The empty directory volume.
        /// </summary>
        public EmptyDirVolume EmptyDir { get; set; }

        /// <summary>
        /// The secret volume.
        /// </summary>
        public SecretVolume Secret { get; set; }

        /// <summary>
        /// Represents a volume that is populated with the contents of a git repository
        /// </summary>
        public GitRepoVolume GitRepo { get; set; }
    }

    /// <summary>
    /// The properties of the volume mount.
    /// </summary>
    public class VolumeMount
    {
        /// <summary>
        /// The name of the volume mount.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The path within the container where the volume should be mounted. Must not contain colon (:).
        /// </summary>
        public string MountPath { get; set; }

        /// <summary>
        /// The flag indicating whether the volume mount is read-only.
        /// </summary>
        public bool ReadOnly { get; set; }
    }
}
namespace AzureMachineLearningTest.Models
{
    /// <summary>
    /// Restart policy for all containers within the container group. - `Always` Always restart- `OnFailure` Restart on failure- `Never` Never restart
    /// </summary>
    public static class ContainerGroupPropertiesRestartPolicyConstants
    {
        public const string Always = "Always";

        public const string OnFailure = "OnFailure";

        public const string Never = "Never";
    }

    /// <summary>
    /// The operating system type required by the containers in the container group.
    /// </summary>
    public static class ContainerGroupPropertiesOsTypeConstants
    {
        public const string Windows = "Windows";

        public const string Linux = "Linux";
    }

    /// <summary>
    /// The container group SKU.
    /// </summary>
    public static class ContainerGroupPropertiesSkuConstants
    {
        public const string Standard = "Standard";

        public const string Dedicated = "Dedicated";
    }

    /// <summary>
    /// The type of identity used for the container group. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities. The type 'None' will remove any identities from the container group.
    /// </summary>
    public static class ContainerGroupIdentityTypeConstants
    {
        public const string SystemAssigned = "SystemAssigned";

        public const string UserAssigned = "UserAssigned";

        public const string SystemAssignedUserAssigned = "SystemAssigned, UserAssigned";

        public const string None = "None";
    }

    /// <summary>
    /// The container group SKU.
    /// </summary>
    public static class ContainerGroupSkuConstants
    {
        public const string Standard = "Standard";

        public const string Dedicated = "Dedicated";
    }

    /// <summary>
    /// The scheme.
    /// </summary>
    public static class ContainerHttpGetSchemeConstants
    {
        public const string Http = "http";

        public const string Https = "https";
    }

    /// <summary>
    /// The protocol associated with the port.
    /// </summary>
    public static class ContainerPortProtocolConstants
    {
        public const string TCP = "TCP";

        public const string UDP = "UDP";
    }

    /// <summary>
    /// The SKU of the GPU resource.
    /// </summary>
    public static class GpuResourceSkuConstants
    {
        public const string K80 = "K80";

        public const string P100 = "P100";

        public const string V100 = "V100";
    }

    /// <summary>
    /// Specifies if the IP is exposed to the public internet or private VNET.
    /// </summary>
    public static class IpAddressTypeConstants
    {
        public const string Public = "Public";

        public const string Private = "Private";
    }

    /// <summary>
    /// The value representing the security enum.
    /// </summary>
    public static class IpAddressDnsNameLabelReusePolicyConstants
    {
        public const string Unsecure = "Unsecure";

        public const string TenantReuse = "TenantReuse";

        public const string SubscriptionReuse = "SubscriptionReuse";

        public const string ResourceGroupReuse = "ResourceGroupReuse";

        public const string Noreuse = "Noreuse";
    }

    /// <summary>
    /// The log type to be used.
    /// </summary>
    public static class LogAnalyticsLogTypeConstants
    {
        public const string ContainerInsights = "ContainerInsights";

        public const string ContainerInstanceLogs = "ContainerInstanceLogs";
    }

    /// <summary>
    /// The intended executor of the operation.
    /// </summary>
    public static class OperationOriginConstants
    {
        public const string User = "User";

        public const string System = "System";
    }

    /// <summary>
    /// The protocol associated with the port.
    /// </summary>
    public static class PortProtocolConstants
    {
        public const string TCP = "TCP";

        public const string UDP = "UDP";
    }
}
