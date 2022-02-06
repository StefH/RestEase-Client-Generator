using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Actions which to take by the auto-heal module when a rule is triggered.
    /// </summary>
    public class AutoHealActions
    {
        /// <summary>
        /// Predefined action to be taken.
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// Custom action to be executedwhen an auto heal rule is triggered.
        /// </summary>
        public AutoHealCustomAction CustomAction { get; set; }

        /// <summary>
        /// Minimum time the process must executebefore taking the action
        /// </summary>
        public string MinProcessExecutionTime { get; set; }
    }
}