using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// App Service plan.
    /// </summary>
    public class AppServicePlan : Resource
    {
        /// <summary>
        /// AppServicePlan resource specific properties
        /// </summary>
        public AppServicePlanProperties Properties { get; set; }

        /// <summary>
        /// Description of a SKU for a scalable resource.
        /// </summary>
        public SkuDescription Sku { get; set; }

        /// <summary>
        /// Extended Location.
        /// </summary>
        public ExtendedLocation ExtendedLocation { get; set; }

    }
}