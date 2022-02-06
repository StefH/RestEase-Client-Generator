using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// VnetGateway resource specific properties
    /// </summary>
    public class VnetGatewayProperties
    {
        /// <summary>
        /// The Virtual Network name.
        /// </summary>
        public string VnetName { get; set; }

        /// <summary>
        /// The URI where the VPN package can be downloaded.
        /// </summary>
        public string VpnPackageUri { get; set; }
    }
}