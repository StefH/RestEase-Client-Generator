using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
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
}