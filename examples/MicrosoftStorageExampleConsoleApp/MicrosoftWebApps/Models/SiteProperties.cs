using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Site resource specific properties
    /// </summary>
    public class SiteProperties
    {
        /// <summary>
        /// Current state of the app.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Hostnames associated with the app.
        /// </summary>
        public string[] HostNames { get; set; }

        /// <summary>
        /// Name of the repository site.
        /// </summary>
        public string RepositorySiteName { get; set; }

        /// <summary>
        /// State indicating whether the app has exceeded its quota usage. Read-only.
        /// </summary>
        public string UsageState { get; set; }

        /// <summary>
        /// true if the app is enabled; otherwise, false. Setting this value to false disables the app (takes the app offline).
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Enabled hostnames for the app.Hostnames need to be assigned (see HostNames) AND enabled. Otherwise,the app is not served on those hostnames.
        /// </summary>
        public string[] EnabledHostNames { get; set; }

        /// <summary>
        /// Management information availability state for the app.
        /// </summary>
        public string AvailabilityState { get; set; }

        /// <summary>
        /// Hostname SSL states are used to manage the SSL bindings for app's hostnames.
        /// </summary>
        public HostNameSslState[] HostNameSslStates { get; set; }

        /// <summary>
        /// Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
        /// </summary>
        public string ServerFarmId { get; set; }

        /// <summary>
        /// true if reserved; otherwise, false.
        /// </summary>
        public bool Reserved { get; set; }

        /// <summary>
        /// Obsolete: Hyper-V sandbox.
        /// </summary>
        public bool IsXenon { get; set; }

        /// <summary>
        /// Hyper-V sandbox.
        /// </summary>
        public bool HyperV { get; set; }

        /// <summary>
        /// Last time the app was modified, in UTC. Read-only.
        /// </summary>
        public DateTime LastModifiedTimeUtc { get; set; }

        /// <summary>
        /// Configuration of an App Service app.
        /// </summary>
        public SiteConfig SiteConfig { get; set; }

        /// <summary>
        /// Azure Traffic Manager hostnames associated with the app. Read-only.
        /// </summary>
        public string[] TrafficManagerHostNames { get; set; }

        /// <summary>
        /// true to stop SCM (KUDU) site when the app is stopped; otherwise, false. The default is false.
        /// </summary>
        public bool ScmSiteAlsoStopped { get; set; }

        /// <summary>
        /// Specifies which deployment slot this app will swap into. Read-only.
        /// </summary>
        public string TargetSwapSlot { get; set; }

        /// <summary>
        /// Specification for an App Service Environment to use for this resource.
        /// </summary>
        public HostingEnvironmentProfile HostingEnvironmentProfile { get; set; }

        /// <summary>
        /// true to enable client affinity; false to stop sending session affinity cookies, which route client requests in the same session to the same instance. Default is true.
        /// </summary>
        public bool ClientAffinityEnabled { get; set; }

        /// <summary>
        /// true to enable client certificate authentication (TLS mutual authentication); otherwise, false. Default is false.
        /// </summary>
        public bool ClientCertEnabled { get; set; }

        /// <summary>
        /// This composes with ClientCertEnabled setting.- ClientCertEnabled: false means ClientCert is ignored.- ClientCertEnabled: true and ClientCertMode: Required means ClientCert is required.- ClientCertEnabled: true and ClientCertMode: Optional means ClientCert is optional or accepted.
        /// </summary>
        public string ClientCertMode { get; set; }

        /// <summary>
        /// client certificate authentication comma-separated exclusion paths
        /// </summary>
        public string ClientCertExclusionPaths { get; set; }

        /// <summary>
        /// true to disable the public hostnames of the app; otherwise, false. If true, the app is only accessible via API management process.
        /// </summary>
        public bool HostNamesDisabled { get; set; }

        /// <summary>
        /// Unique identifier that verifies the custom domains assigned to the app. Customer will add this id to a txt record for verification.
        /// </summary>
        public string CustomDomainVerificationId { get; set; }

        /// <summary>
        /// List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from tenants that site can be hosted with current settings. Read-only.
        /// </summary>
        public string OutboundIpAddresses { get; set; }

        /// <summary>
        /// List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from all tenants except dataComponent. Read-only.
        /// </summary>
        public string PossibleOutboundIpAddresses { get; set; }

        /// <summary>
        /// Size of the function container.
        /// </summary>
        public int ContainerSize { get; set; }

        /// <summary>
        /// Maximum allowed daily memory-time quota (applicable on dynamic apps only).
        /// </summary>
        public int DailyMemoryTimeQuota { get; set; }

        /// <summary>
        /// App suspended till in case memory-time quota is exceeded.
        /// </summary>
        public DateTime SuspendedTill { get; set; }

        /// <summary>
        /// Maximum number of workers.This only applies to Functions container.
        /// </summary>
        public int MaxNumberOfWorkers { get; set; }

        /// <summary>
        /// Information needed for cloning operation.
        /// </summary>
        public CloningInfo CloningInfo { get; set; }

        /// <summary>
        /// Name of the resource group the app belongs to. Read-only.
        /// </summary>
        public string ResourceGroup { get; set; }

        /// <summary>
        /// true if the app is a default container; otherwise, false.
        /// </summary>
        public bool IsDefaultContainer { get; set; }

        /// <summary>
        /// Default hostname of the app. Read-only.
        /// </summary>
        public string DefaultHostName { get; set; }

        /// <summary>
        /// The status of the last successful slot swap operation.
        /// </summary>
        public SlotSwapStatus SlotSwapStatus { get; set; }

        /// <summary>
        /// HttpsOnly: configures a web site to accept only https requests. Issues redirect forhttp requests
        /// </summary>
        public bool HttpsOnly { get; set; }

        /// <summary>
        /// Site redundancy mode
        /// </summary>
        public string RedundancyMode { get; set; }

        /// <summary>
        /// Specifies an operation id if this site has a pending operation.
        /// </summary>
        public string InProgressOperationId { get; set; }

        /// <summary>
        /// Checks if Customer provided storage account is required
        /// </summary>
        public bool StorageAccountRequired { get; set; }

        /// <summary>
        /// Identity to use for Key Vault Reference authentication.
        /// </summary>
        public string KeyVaultReferenceIdentity { get; set; }

        /// <summary>
        /// Azure Resource Manager ID of the Virtual network and subnet to be joined by Regional VNET Integration.This must be of the form /subscriptions/{subscriptionName}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}
        /// </summary>
        public string VirtualNetworkSubnetId { get; set; }
    }
}