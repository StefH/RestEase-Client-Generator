using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of App Service plans.
    /// </summary>
    public class AppServicePlanCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public AppServicePlan[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}