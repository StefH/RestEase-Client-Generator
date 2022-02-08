using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Process Module Information.
    /// </summary>
    public class ProcessModuleInfo : ProxyOnlyResource
    {
        /// <summary>
        /// ProcessModuleInfo resource specific properties
        /// </summary>
        public ProcessModuleInfoProperties Properties { get; set; }

    }
}