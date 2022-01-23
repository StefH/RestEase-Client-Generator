using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Network rule set
    /// </summary>
    public class NetworkRuleSet
    {
        /// <summary>
        /// Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.
        /// </summary>
        public string Bypass { get; set; }

        /// <summary>
        /// Sets the resource access rules
        /// </summary>
        public ResourceAccessRule[] ResourceAccessRules { get; set; }

        /// <summary>
        /// Sets the virtual network rules
        /// </summary>
        public VirtualNetworkRule[] VirtualNetworkRules { get; set; }

        /// <summary>
        /// Sets the IP ACL rules
        /// </summary>
        public IPRule[] IpRules { get; set; }

        /// <summary>
        /// Specifies the default action of allow or deny when no other rules match.
        /// </summary>
        public string DefaultAction { get; set; }
    }
}