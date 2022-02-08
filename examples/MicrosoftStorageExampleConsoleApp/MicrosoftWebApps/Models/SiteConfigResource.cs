using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Web app configuration ARM resource.
    /// </summary>
    public class SiteConfigResource : ProxyOnlyResource
    {
        /// <summary>
        /// not-used
        /// </summary>
        public SiteConfig Properties { get; set; }

    }
}