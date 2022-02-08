using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Description of a SKU for a scalable resource.
    /// </summary>
    public class SkuDescription
    {
        /// <summary>
        /// Name of the resource SKU.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Service tier of the resource SKU.
        /// </summary>
        public string Tier { get; set; }

        /// <summary>
        /// Size specifier of the resource SKU.
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Family code of the resource SKU.
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// Current number of instances assigned to the resource.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Description of the App Service plan scale options.
        /// </summary>
        public SkuCapacity SkuCapacity { get; set; }

        /// <summary>
        /// Locations of the SKU.
        /// </summary>
        public string[] Locations { get; set; }

        /// <summary>
        /// Capabilities of the SKU, e.g., is traffic manager enabled?
        /// </summary>
        public Capability[] Capabilities { get; set; }
    }
}