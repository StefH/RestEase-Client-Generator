using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class PrivateEndpointConnectionProperties
    {
        public PrivateEndpoint PrivateEndpoint { get; set; }

        public PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; set; }

        public string ProvisioningState { get; set; }
    }
}