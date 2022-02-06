using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Configuration of an App Service app.
    /// </summary>
    public class SiteConfig
    {
        /// <summary>
        /// Number of workers.
        /// </summary>
        public int NumberOfWorkers { get; set; }

        /// <summary>
        /// Default documents.
        /// </summary>
        public string[] DefaultDocuments { get; set; }

        /// <summary>
        /// .NET Framework version.
        /// </summary>
        public string NetFrameworkVersion { get; set; }

        /// <summary>
        /// Version of PHP.
        /// </summary>
        public string PhpVersion { get; set; }

        /// <summary>
        /// Version of Python.
        /// </summary>
        public string PythonVersion { get; set; }

        /// <summary>
        /// Version of Node.js.
        /// </summary>
        public string NodeVersion { get; set; }

        /// <summary>
        /// Version of PowerShell.
        /// </summary>
        public string PowerShellVersion { get; set; }

        /// <summary>
        /// Linux App Framework and version
        /// </summary>
        public string LinuxFxVersion { get; set; }

        /// <summary>
        /// Xenon App Framework and version
        /// </summary>
        public string WindowsFxVersion { get; set; }

        /// <summary>
        /// true if request tracing is enabled; otherwise, false.
        /// </summary>
        public bool RequestTracingEnabled { get; set; }

        /// <summary>
        /// Request tracing expiration time.
        /// </summary>
        public DateTime RequestTracingExpirationTime { get; set; }

        /// <summary>
        /// true if remote debugging is enabled; otherwise, false.
        /// </summary>
        public bool RemoteDebuggingEnabled { get; set; }

        /// <summary>
        /// Remote debugging version.
        /// </summary>
        public string RemoteDebuggingVersion { get; set; }

        /// <summary>
        /// true if HTTP logging is enabled; otherwise, false.
        /// </summary>
        public bool HttpLoggingEnabled { get; set; }

        /// <summary>
        /// Flag to use Managed Identity Creds for ACR pull
        /// </summary>
        public bool AcrUseManagedIdentityCreds { get; set; }

        /// <summary>
        /// If using user managed identity, the user managed identity ClientId
        /// </summary>
        public string AcrUserManagedIdentityID { get; set; }

        /// <summary>
        /// HTTP logs directory size limit.
        /// </summary>
        public int LogsDirectorySizeLimit { get; set; }

        /// <summary>
        /// true if detailed error logging is enabled; otherwise, false.
        /// </summary>
        public bool DetailedErrorLoggingEnabled { get; set; }

        /// <summary>
        /// Publishing user name.
        /// </summary>
        public string PublishingUsername { get; set; }

        /// <summary>
        /// Application settings.
        /// </summary>
        public NameValuePair[] AppSettings { get; set; }

        /// <summary>
        /// Connection strings.
        /// </summary>
        public ConnStringInfo[] ConnectionStrings { get; set; }

        /// <summary>
        /// MachineKey of an app.
        /// </summary>
        public SiteMachineKey MachineKey { get; set; }

        /// <summary>
        /// Handler mappings.
        /// </summary>
        public HandlerMapping[] HandlerMappings { get; set; }

        /// <summary>
        /// Document root.
        /// </summary>
        public string DocumentRoot { get; set; }

        /// <summary>
        /// SCM type.
        /// </summary>
        public string ScmType { get; set; }

        /// <summary>
        /// true to use 32-bit worker process; otherwise, false.
        /// </summary>
        public bool Use32BitWorkerProcess { get; set; }

        /// <summary>
        /// true if WebSocket is enabled; otherwise, false.
        /// </summary>
        public bool WebSocketsEnabled { get; set; }

        /// <summary>
        /// true if Always On is enabled; otherwise, false.
        /// </summary>
        public bool AlwaysOn { get; set; }

        /// <summary>
        /// Java version.
        /// </summary>
        public string JavaVersion { get; set; }

        /// <summary>
        /// Java container.
        /// </summary>
        public string JavaContainer { get; set; }

        /// <summary>
        /// Java container version.
        /// </summary>
        public string JavaContainerVersion { get; set; }

        /// <summary>
        /// App command line to launch.
        /// </summary>
        public string AppCommandLine { get; set; }

        /// <summary>
        /// Managed pipeline mode.
        /// </summary>
        public string ManagedPipelineMode { get; set; }

        /// <summary>
        /// Virtual applications.
        /// </summary>
        public VirtualApplication[] VirtualApplications { get; set; }

        /// <summary>
        /// Site load balancing.
        /// </summary>
        public string LoadBalancing { get; set; }

        /// <summary>
        /// Routing rules in production experiments.
        /// </summary>
        public Experiments Experiments { get; set; }

        /// <summary>
        /// Metric limits set on an app.
        /// </summary>
        public SiteLimits Limits { get; set; }

        /// <summary>
        /// true if Auto Heal is enabled; otherwise, false.
        /// </summary>
        public bool AutoHealEnabled { get; set; }

        /// <summary>
        /// Rules that can be defined for auto-heal.
        /// </summary>
        public AutoHealRules AutoHealRules { get; set; }

        /// <summary>
        /// Tracing options.
        /// </summary>
        public string TracingOptions { get; set; }

        /// <summary>
        /// Virtual Network name.
        /// </summary>
        public string VnetName { get; set; }

        /// <summary>
        /// Virtual Network Route All enabled. This causes all outbound traffic to have Virtual Network Security Groups and User Defined Routes applied.
        /// </summary>
        public bool VnetRouteAllEnabled { get; set; }

        /// <summary>
        /// The number of private ports assigned to this app. These will be assigned dynamically on runtime.
        /// </summary>
        public int VnetPrivatePortsCount { get; set; }

        /// <summary>
        /// Cross-Origin Resource Sharing (CORS) settings for the app.
        /// </summary>
        public CorsSettings Cors { get; set; }

        /// <summary>
        /// Push settings for the App.
        /// </summary>
        public PushSettings Push { get; set; }

        /// <summary>
        /// Information about the formal API definition for the app.
        /// </summary>
        public ApiDefinitionInfo ApiDefinition { get; set; }

        /// <summary>
        /// Azure API management (APIM) configuration linked to the app.
        /// </summary>
        public ApiManagementConfig ApiManagementConfig { get; set; }

        /// <summary>
        /// Auto-swap slot name.
        /// </summary>
        public string AutoSwapSlotName { get; set; }

        /// <summary>
        /// true to enable local MySQL; otherwise, false.
        /// </summary>
        public bool LocalMySqlEnabled { get; set; }

        /// <summary>
        /// Managed Service Identity Id
        /// </summary>
        public int ManagedServiceIdentityId { get; set; }

        /// <summary>
        /// Explicit Managed Service Identity Id
        /// </summary>
        public int XManagedServiceIdentityId { get; set; }

        /// <summary>
        /// Identity to use for Key Vault Reference authentication.
        /// </summary>
        public string KeyVaultReferenceIdentity { get; set; }

        /// <summary>
        /// IP security restrictions for main.
        /// </summary>
        public IpSecurityRestriction[] IpSecurityRestrictions { get; set; }

        /// <summary>
        /// IP security restrictions for scm.
        /// </summary>
        public IpSecurityRestriction[] ScmIpSecurityRestrictions { get; set; }

        /// <summary>
        /// IP security restrictions for scm to use main.
        /// </summary>
        public bool ScmIpSecurityRestrictionsUseMain { get; set; }

        /// <summary>
        /// Http20Enabled: configures a web site to allow clients to connect over http2.0
        /// </summary>
        public bool Http20Enabled { get; set; }

        /// <summary>
        /// MinTlsVersion: configures the minimum version of TLS required for SSL requests
        /// </summary>
        public string MinTlsVersion { get; set; }

        /// <summary>
        /// ScmMinTlsVersion: configures the minimum version of TLS required for SSL requests for SCM site
        /// </summary>
        public string ScmMinTlsVersion { get; set; }

        /// <summary>
        /// State of FTP / FTPS service
        /// </summary>
        public string FtpsState { get; set; }

        /// <summary>
        /// Number of preWarmed instances.This setting only applies to the Consumption and Elastic Plans
        /// </summary>
        public int PreWarmedInstanceCount { get; set; }

        /// <summary>
        /// Maximum number of workers that a site can scale out to.This setting only applies to the Consumption and Elastic Premium Plans
        /// </summary>
        public int FunctionAppScaleLimit { get; set; }

        /// <summary>
        /// Health check path
        /// </summary>
        public string HealthCheckPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether functions runtime scale monitoring is enabled. When enabled,the ScaleController will not monitor event sources directly, but will instead call to theruntime to get scale status.
        /// </summary>
        public bool FunctionsRuntimeScaleMonitoringEnabled { get; set; }

        /// <summary>
        /// Sets the time zone a site uses for generating timestamps. Compatible with Linux and Windows App Service. Setting the WEBSITE_TIME_ZONE app setting takes precedence over this config. For Linux, expects tz database values https://www.iana.org/time-zones (for a quick reference see https://en.wikipedia.org/wiki/List_of_tz_database_time_zones). For Windows, expects one of the time zones listed under HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Time Zones
        /// </summary>
        public string WebsiteTimeZone { get; set; }

        /// <summary>
        /// Number of minimum instance count for a siteThis setting only applies to the Elastic Plans
        /// </summary>
        public int MinimumElasticInstanceCount { get; set; }

        /// <summary>
        /// List of Azure Storage Accounts.
        /// </summary>
        public Dictionary<string, AzureStorageInfoValue> AzureStorageAccounts { get; set; }

        /// <summary>
        /// Property to allow or block all public traffic.
        /// </summary>
        public string PublicNetworkAccess { get; set; }
    }
}