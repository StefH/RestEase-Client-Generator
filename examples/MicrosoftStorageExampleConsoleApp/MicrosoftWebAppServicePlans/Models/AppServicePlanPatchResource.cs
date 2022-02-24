using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// ARM resource for a app service plan.
    /// </summary>
    public class AppServicePlanPatchResource : ProxyOnlyResource 
    {
        /// <summary>
        /// AppServicePlanPatchResource resource specific properties
        /// </summary>
        public AppServicePlanPatchResourceProperties Properties { get; set; }

    }
}