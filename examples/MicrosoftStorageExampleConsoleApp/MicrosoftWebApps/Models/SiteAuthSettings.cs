using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Configuration settings for the Azure App Service Authentication / Authorization feature.
    /// </summary>
    public class SiteAuthSettings : ProxyOnlyResource
    {
        /// <summary>
        /// SiteAuthSettings resource specific properties
        /// </summary>
        public SiteAuthSettingsProperties Properties { get; set; }

    }
}