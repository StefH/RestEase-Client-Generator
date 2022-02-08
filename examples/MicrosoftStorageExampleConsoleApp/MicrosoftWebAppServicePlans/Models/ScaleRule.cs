using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Container App container scaling rule.
    /// </summary>
    public class ScaleRule
    {
        /// <summary>
        /// Scale Rule Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Container App container Azure Queue based scaling rule.
        /// </summary>
        public QueueScaleRule AzureQueue { get; set; }

        /// <summary>
        /// Container App container Custom scaling rule.
        /// </summary>
        public CustomScaleRule Custom { get; set; }

        /// <summary>
        /// Container App container Custom scaling rule.
        /// </summary>
        public HttpScaleRule Http { get; set; }
    }
}