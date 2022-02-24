using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// A hostname binding object.
    /// </summary>
    public class HostNameBinding : ProxyOnlyResource 
    {
        /// <summary>
        /// HostNameBinding resource specific properties
        /// </summary>
        public HostNameBindingProperties Properties { get; set; }

    }
}