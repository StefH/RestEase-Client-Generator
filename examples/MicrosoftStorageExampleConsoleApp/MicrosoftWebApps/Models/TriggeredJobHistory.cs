using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Triggered Web Job History. List of Triggered Web Job Run Information elements.
    /// </summary>
    public class TriggeredJobHistory : ProxyOnlyResource
    {
        /// <summary>
        /// TriggeredJobHistory resource specific properties
        /// </summary>
        public TriggeredJobHistoryProperties Properties { get; set; }

    }
}