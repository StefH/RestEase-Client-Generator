using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of site configurations.
    /// </summary>
    public class SiteConfigResourceCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public SiteConfigResource[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}