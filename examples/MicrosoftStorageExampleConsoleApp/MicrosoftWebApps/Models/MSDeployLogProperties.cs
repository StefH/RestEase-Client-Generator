using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// MSDeployLog resource specific properties
    /// </summary>
    public class MSDeployLogProperties
    {
        /// <summary>
        /// List of log entry messages
        /// </summary>
        public MSDeployLogEntry[] Entries { get; set; }
    }
}