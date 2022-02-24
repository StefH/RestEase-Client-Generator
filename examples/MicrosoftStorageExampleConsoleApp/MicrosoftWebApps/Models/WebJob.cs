using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Web Job Information.
    /// </summary>
    public class WebJob : ProxyOnlyResource 
    {
        /// <summary>
        /// WebJob resource specific properties
        /// </summary>
        public WebJobProperties Properties { get; set; }

    }
}