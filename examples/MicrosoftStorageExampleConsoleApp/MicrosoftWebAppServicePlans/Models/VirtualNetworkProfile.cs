using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Specification for using a Virtual Network.
    /// </summary>
    public class VirtualNetworkProfile
    {
        /// <summary>
        /// Resource id of the Virtual Network.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the Virtual Network (read-only).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Resource type of the Virtual Network (read-only).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Subnet within the Virtual Network.
        /// </summary>
        public string Subnet { get; set; }
    }
}