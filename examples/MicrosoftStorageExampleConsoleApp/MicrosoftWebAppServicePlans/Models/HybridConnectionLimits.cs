using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Hybrid Connection limits contract. This is used to return the plan limits of Hybrid Connections.
    /// </summary>
    public class HybridConnectionLimits : ProxyOnlyResource 
    {
        /// <summary>
        /// HybridConnectionLimits resource specific properties
        /// </summary>
        public HybridConnectionLimitsProperties Properties { get; set; }

    }
}