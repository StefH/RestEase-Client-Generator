using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Process Information.
    /// </summary>
    public class ProcessInfo : ProxyOnlyResource
    {
        /// <summary>
        /// ProcessInfo resource specific properties
        /// </summary>
        public ProcessInfoProperties Properties { get; set; }

    }
}