using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Collection of App Service apps.
    /// </summary>
    public class WebAppCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public Site[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}