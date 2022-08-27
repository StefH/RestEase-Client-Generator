using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The Private Endpoint Connection resource.
    /// </summary>
    public class PrivateEndpointConnection : Resource
    {
        /// <summary>
        /// Properties of the PrivateEndpointConnectProperties.
        /// </summary>
        public PrivateEndpointConnectionProperties Properties { get; set; }
    }
}