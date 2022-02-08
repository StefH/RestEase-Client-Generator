using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Container App container Azure Queue based scaling rule.
    /// </summary>
    public class QueueScaleRule
    {
        /// <summary>
        /// Queue name.
        /// </summary>
        public string QueueName { get; set; }

        /// <summary>
        /// Queue length.
        /// </summary>
        public int QueueLength { get; set; }

        /// <summary>
        /// Authentication secrets for the queue scale rule.
        /// </summary>
        public ScaleRuleAuth[] Auth { get; set; }
    }
}