using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Description of an App Service Environment.
    /// </summary>
    public class AppServiceEnvironment
    {
        /// <summary>
        /// Provisioning state of the App Service Environment.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Current status of the App Service Environment.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Specification for using a Virtual Network.
        /// </summary>
        public VirtualNetworkProfile VirtualNetwork { get; set; }

        /// <summary>
        /// Specifies which endpoints to serve internally in the Virtual Network for the App Service Environment.
        /// </summary>
        public string InternalLoadBalancingMode { get; set; }

        /// <summary>
        /// Front-end VM size, e.g. "Medium", "Large".
        /// </summary>
        public string MultiSize { get; set; }

        /// <summary>
        /// Number of front-end instances.
        /// </summary>
        public int MultiRoleCount { get; set; }

        /// <summary>
        /// Number of IP SSL addresses reserved for the App Service Environment.
        /// </summary>
        public int IpsslAddressCount { get; set; }

        /// <summary>
        /// DNS suffix of the App Service Environment.
        /// </summary>
        public string DnsSuffix { get; set; }

        /// <summary>
        /// Maximum number of VMs in the App Service Environment.
        /// </summary>
        public int MaximumNumberOfMachines { get; set; }

        /// <summary>
        /// Scale factor for front-ends.
        /// </summary>
        public int FrontEndScaleFactor { get; set; }

        /// <summary>
        /// true if the App Service Environment is suspended; otherwise, false. The environment can be suspended, e.g. when the management endpoint is no longer available (most likely because NSG blocked the incoming traffic).
        /// </summary>
        public bool Suspended { get; set; }

        /// <summary>
        /// Custom settings for changing the behavior of the App Service Environment.
        /// </summary>
        public NameValuePair[] ClusterSettings { get; set; }

        /// <summary>
        /// User added ip ranges to whitelist on ASE db
        /// </summary>
        public string[] UserWhitelistedIpRanges { get; set; }

        /// <summary>
        /// Flag that displays whether an ASE has linux workers or not
        /// </summary>
        public bool HasLinuxWorkers { get; set; }

        /// <summary>
        /// Dedicated Host Count
        /// </summary>
        public int DedicatedHostCount { get; set; }

        /// <summary>
        /// Whether or not this App Service Environment is zone-redundant.
        /// </summary>
        public bool ZoneRedundant { get; set; }
    }
}