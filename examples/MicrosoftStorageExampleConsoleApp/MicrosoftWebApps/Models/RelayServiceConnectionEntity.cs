using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Hybrid Connection for an App Service app.
    /// </summary>
    public class RelayServiceConnectionEntity : ProxyOnlyResource 
    {
        /// <summary>
        /// RelayServiceConnectionEntity resource specific properties
        /// </summary>
        public RelayServiceConnectionEntityProperties Properties { get; set; }

    }
}