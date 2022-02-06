using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Virtual Network information ARM resource.
    /// </summary>
    public class VnetInfoResource : ProxyOnlyResource
    {
        /// <summary>
        /// Virtual Network information contract.
        /// </summary>
        public VnetInfo Properties { get; set; }

    }
}