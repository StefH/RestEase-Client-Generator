using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Site Extension Information.
    /// </summary>
    public class SiteExtensionInfo : ProxyOnlyResource
    {
        /// <summary>
        /// SiteExtensionInfo resource specific properties
        /// </summary>
        public SiteExtensionInfoProperties Properties { get; set; }

    }
}