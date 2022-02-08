using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of Kudu site extension information elements.
    /// </summary>
    public class SiteExtensionInfoCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public SiteExtensionInfo[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}