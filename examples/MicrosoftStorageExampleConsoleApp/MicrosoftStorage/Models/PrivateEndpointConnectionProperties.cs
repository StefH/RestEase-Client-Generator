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
        /// The Private Endpoint resource.
        /// </summary>
        public PrivateEndpoint PrivateEndpoint { get; set; }

        /// <summary>
        /// A collection of information about the state of the connection between service consumer and provider.
        /// </summary>
        public PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; set; }

        /// <summary>
        /// The current provisioning state.
        /// </summary>
        public string ProvisioningState { get; set; }
    }
}