using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Hybrid Connection key contract. This has the send key name and value for a Hybrid Connection.
    /// </summary>
    public class HybridConnectionKey : ProxyOnlyResource 
    {
        /// <summary>
        /// HybridConnectionKey resource specific properties
        /// </summary>
        public HybridConnectionKeyProperties Properties { get; set; }

    }
}