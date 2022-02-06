using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// MSDeploy log entry
    /// </summary>
    public class MSDeployLogEntry
    {
        /// <summary>
        /// Timestamp of log entry
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Log entry type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Log entry message
        /// </summary>
        public string Message { get; set; }
    }
}