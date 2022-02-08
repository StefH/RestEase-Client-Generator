using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Remote Private Endpoint Connection ARM resource.
    /// </summary>
    public class RemotePrivateEndpointConnectionARMResource : ProxyOnlyResource
    {
        /// <summary>
        /// RemotePrivateEndpointConnectionARMResource resource specific properties
        /// </summary>
        public RemotePrivateEndpointConnectionARMResourceProperties Properties { get; set; }

    }
}