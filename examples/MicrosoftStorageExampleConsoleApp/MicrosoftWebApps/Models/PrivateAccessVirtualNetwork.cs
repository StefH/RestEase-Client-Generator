using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Description of a Virtual Network that is useable for private site access.
    /// </summary>
    public class PrivateAccessVirtualNetwork
    {
        /// <summary>
        /// The name of the Virtual Network.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The key (ID) of the Virtual Network.
        /// </summary>
        public int Key { get; set; }

        /// <summary>
        /// The ARM uri of the Virtual Network
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// A List of subnets that access is allowed to on this Virtual Network. An empty array (but not null) is interpreted to mean that all subnets are allowed within this Virtual Network.
        /// </summary>
        public PrivateAccessSubnet[] Subnets { get; set; }
    }
}