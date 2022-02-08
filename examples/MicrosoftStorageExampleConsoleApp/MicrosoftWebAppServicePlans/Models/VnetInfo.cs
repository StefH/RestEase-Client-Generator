using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Virtual Network information contract.
    /// </summary>
    public class VnetInfo
    {
        /// <summary>
        /// The Virtual Network's resource ID.
        /// </summary>
        public string VnetResourceId { get; set; }

        /// <summary>
        /// The client certificate thumbprint.
        /// </summary>
        public string CertThumbprint { get; set; }

        /// <summary>
        /// A certificate file (.cer) blob containing the public key of the private key used to authenticate a Point-To-Site VPN connection.
        /// </summary>
        public string CertBlob { get; set; }

        /// <summary>
        /// The routes that this Virtual Network connection uses.
        /// </summary>
        public VnetRoute[] Routes { get; set; }

        /// <summary>
        /// true if a resync is required; otherwise, false.
        /// </summary>
        public bool ResyncRequired { get; set; }

        /// <summary>
        /// DNS servers to be used by this Virtual Network. This should be a comma-separated list of IP addresses.
        /// </summary>
        public string DnsServers { get; set; }

        /// <summary>
        /// Flag that is used to denote if this is VNET injection
        /// </summary>
        public bool IsSwift { get; set; }
    }
}