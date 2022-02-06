using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// RemotePrivateEndpointConnectionARMResource resource specific properties
    /// </summary>
    public class RemotePrivateEndpointConnectionARMResourceProperties
    {
        public string ProvisioningState { get; set; }

        /// <summary>
        /// A wrapper for an ARM resource id
        /// </summary>
        public ArmIdWrapper PrivateEndpoint { get; set; }

        /// <summary>
        /// The state of a private link connection
        /// </summary>
        public PrivateLinkConnectionState PrivateLinkServiceConnectionState { get; set; }

        /// <summary>
        /// Private IPAddresses mapped to the remote private endpoint
        /// </summary>
        public string[] IpAddresses { get; set; }
    }
}