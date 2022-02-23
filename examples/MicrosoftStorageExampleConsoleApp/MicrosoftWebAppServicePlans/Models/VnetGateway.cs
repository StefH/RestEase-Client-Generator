using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// The Virtual Network gateway contract. This is used to give the Virtual Network gateway access to the VPN package.
    /// </summary>
    public class VnetGateway : ProxyOnlyResource 
    {
        /// <summary>
        /// VnetGateway resource specific properties
        /// </summary>
        public VnetGatewayProperties Properties { get; set; }

    }
}