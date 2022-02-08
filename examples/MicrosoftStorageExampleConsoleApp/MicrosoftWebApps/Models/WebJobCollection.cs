using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of Kudu web job information elements.
    /// </summary>
    public class WebJobCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public WebJob[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}