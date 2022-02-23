using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Source control configuration for an app.
    /// </summary>
    public class SiteSourceControl : ProxyOnlyResource 
    {
        /// <summary>
        /// SiteSourceControl resource specific properties
        /// </summary>
        public SiteSourceControlProperties Properties { get; set; }

    }
}