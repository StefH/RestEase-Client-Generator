using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// SwiftVirtualNetwork resource specific properties
    /// </summary>
    public class SwiftVirtualNetworkProperties
    {
        /// <summary>
        /// The Virtual Network subnet's resource ID. This is the subnet that this Web App will join. This subnet must have a delegation to Microsoft.Web/serverFarms defined first.
        /// </summary>
        public string SubnetResourceId { get; set; }

        /// <summary>
        /// A flag that specifies if the scale unit this Web App is on supports Swift integration.
        /// </summary>
        public bool SwiftSupported { get; set; }
    }
}