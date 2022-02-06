using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Routing rules in production experiments.
    /// </summary>
    public class Experiments
    {
        /// <summary>
        /// List of ramp-up rules.
        /// </summary>
        public RampUpRule[] RampUpRules { get; set; }
    }
}