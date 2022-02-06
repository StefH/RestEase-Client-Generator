using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Swift Virtual Network Contract. This is used to enable the new Swift way of doing virtual network integration.
    /// </summary>
    public class SwiftVirtualNetwork : ProxyOnlyResource
    {
        /// <summary>
        /// SwiftVirtualNetwork resource specific properties
        /// </summary>
        public SwiftVirtualNetworkProperties Properties { get; set; }

    }
}