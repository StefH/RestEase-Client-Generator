using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Container App container Custom scaling rule.
    /// </summary>
    public class HttpScaleRule
    {
        /// <summary>
        /// Metadata properties to describe http scale rule.
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Authentication secrets for the custom scale rule.
        /// </summary>
        public ScaleRuleAuth[] Auth { get; set; }
    }
}