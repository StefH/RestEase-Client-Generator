using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Rules that can be defined for auto-heal.
    /// </summary>
    public class AutoHealRules
    {
        /// <summary>
        /// Triggers for auto-heal.
        /// </summary>
        public AutoHealTriggers Triggers { get; set; }

        /// <summary>
        /// Actions which to take by the auto-heal module when a rule is triggered.
        /// </summary>
        public AutoHealActions Actions { get; set; }
    }
}