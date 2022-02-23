using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Configuration settings for the Azure App Service Authentication / Authorization V2 feature.
    /// </summary>
    public class SiteAuthSettingsV2 : ProxyOnlyResource 
    {
        /// <summary>
        /// SiteAuthSettingsV2 resource specific properties
        /// </summary>
        public SiteAuthSettingsV2Properties Properties { get; set; }

    }
}