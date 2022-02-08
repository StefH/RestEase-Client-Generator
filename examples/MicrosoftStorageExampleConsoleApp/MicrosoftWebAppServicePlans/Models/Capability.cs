using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Describes the capabilities/features allowed for a specific SKU.
    /// </summary>
    public class Capability
    {
        /// <summary>
        /// Name of the SKU capability.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of the SKU capability.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Reason of the SKU capability.
        /// </summary>
        public string Reason { get; set; }
    }
}