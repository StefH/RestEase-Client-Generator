using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Configuration of App Service site logs.
    /// </summary>
    public class SiteLogsConfig : ProxyOnlyResource
    {
        /// <summary>
        /// SiteLogsConfig resource specific properties
        /// </summary>
        public SiteLogsConfigProperties Properties { get; set; }

    }
}