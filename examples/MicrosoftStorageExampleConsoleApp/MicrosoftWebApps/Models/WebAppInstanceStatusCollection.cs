using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of app instances.
    /// </summary>
    public class WebAppInstanceStatusCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public WebSiteInstanceStatus[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}