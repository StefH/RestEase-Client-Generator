using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Collection of resources.
    /// </summary>
    public class ResourceCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public string[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}