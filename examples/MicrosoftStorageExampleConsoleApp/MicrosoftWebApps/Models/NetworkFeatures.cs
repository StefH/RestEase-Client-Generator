using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Full view of network features for an app (presently VNET integration and Hybrid Connections).
    /// </summary>
    public class NetworkFeatures : ProxyOnlyResource 
    {
        /// <summary>
        /// NetworkFeatures resource specific properties
        /// </summary>
        public NetworkFeaturesProperties Properties { get; set; }

    }
}