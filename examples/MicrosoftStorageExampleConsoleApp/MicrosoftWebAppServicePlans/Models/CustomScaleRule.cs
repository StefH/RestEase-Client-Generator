using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Container App container Custom scaling rule.
    /// </summary>
    public class CustomScaleRule
    {
        /// <summary>
        /// Type of the custom scale ruleeg: azure-servicebus, redis etc.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Metadata properties to describe custom scale rule.
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Authentication secrets for the custom scale rule.
        /// </summary>
        public ScaleRuleAuth[] Auth { get; set; }
    }
}