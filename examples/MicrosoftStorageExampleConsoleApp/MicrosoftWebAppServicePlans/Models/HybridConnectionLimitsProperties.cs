using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// HybridConnectionLimits resource specific properties
    /// </summary>
    public class HybridConnectionLimitsProperties
    {
        /// <summary>
        /// The current number of Hybrid Connections.
        /// </summary>
        public int Current { get; set; }

        /// <summary>
        /// The maximum number of Hybrid Connections allowed.
        /// </summary>
        public int Maximum { get; set; }
    }
}