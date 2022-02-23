using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    public class WebSiteInstanceStatus : ProxyOnlyResource 
    {
        /// <summary>
        /// WebSiteInstanceStatus resource specific properties
        /// </summary>
        public WebSiteInstanceStatusProperties Properties { get; set; }

    }
}