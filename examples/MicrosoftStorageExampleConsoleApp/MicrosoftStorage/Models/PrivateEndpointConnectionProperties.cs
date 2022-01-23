using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Properties of the PrivateEndpointConnectProperties.
    /// </summary>
    public class PrivateEndpointConnectionProperties
    {
        /// <summary>
        /// not-used
        /// </summary>
        public PrivateEndpoint PrivateEndpoint { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; set; }

        /// <summary>
        /// The current provisioning state.
        /// </summary>
        public string ProvisioningState { get; set; }
    }
}