using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Virtual Network route contract used to pass routing information for a Virtual Network.
    /// </summary>
    public class VnetRoute : ProxyOnlyResource 
    {
        /// <summary>
        /// VnetRoute resource specific properties
        /// </summary>
        public VnetRouteProperties Properties { get; set; }

    }
}