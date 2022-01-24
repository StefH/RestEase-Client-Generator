using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Plan for the resource.
    /// </summary>
    public class Plan
    {
        /// <summary>
        /// A user defined name of the 3rd Party Artifact that is being procured.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The publisher of the 3rd Party Artifact that is being bought. E.g. NewRelic
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// The 3rd Party artifact that is being procured. E.g. NewRelic. Product maps to the OfferID specified for the artifact at the time of Data Market onboarding. 
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// A publisher provided promotion code as provisioned in Data Market for the said product/artifact.
        /// </summary>
        public string PromotionCode { get; set; }

        /// <summary>
        /// The version of the desired product/artifact.
        /// </summary>
        public string Version { get; set; }
    }
}