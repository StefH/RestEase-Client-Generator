using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Hybrid Connection contract. This is used to configure a Hybrid Connection.
    /// </summary>
    public class HybridConnection : ProxyOnlyResource
    {
        /// <summary>
        /// HybridConnection resource specific properties
        /// </summary>
        public HybridConnectionProperties Properties { get; set; }

    }
}