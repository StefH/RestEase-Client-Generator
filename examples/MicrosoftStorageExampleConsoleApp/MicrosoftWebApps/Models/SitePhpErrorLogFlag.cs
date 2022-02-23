using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Used for getting PHP error logging flag.
    /// </summary>
    public class SitePhpErrorLogFlag : ProxyOnlyResource 
    {
        /// <summary>
        /// SitePhpErrorLogFlag resource specific properties
        /// </summary>
        public SitePhpErrorLogFlagProperties Properties { get; set; }

    }
}