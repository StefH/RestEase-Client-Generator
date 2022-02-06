using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// NetworkFeatures resource specific properties
    /// </summary>
    public class NetworkFeaturesProperties
    {
        /// <summary>
        /// The Virtual Network name.
        /// </summary>
        public string VirtualNetworkName { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public VnetInfo VirtualNetworkConnection { get; set; }

        /// <summary>
        /// The Hybrid Connections summary view.
        /// </summary>
        public RelayServiceConnectionEntity[] HybridConnections { get; set; }

        /// <summary>
        /// The Hybrid Connection V2 (Service Bus) view.
        /// </summary>
        public HybridConnection[] HybridConnectionsV2 { get; set; }
    }
}