using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Process Thread Information.
    /// </summary>
    public class ProcessThreadInfo : ProxyOnlyResource 
    {
        /// <summary>
        /// ProcessThreadInfo resource specific properties
        /// </summary>
        public ProcessThreadInfoProperties Properties { get; set; }

    }
}