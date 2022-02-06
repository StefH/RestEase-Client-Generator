using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Network trace
    /// </summary>
    public class NetworkTrace
    {
        /// <summary>
        /// Local file path for the captured network trace file.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Current status of the network trace operation, same as Operation.Status (InProgress/Succeeded/Failed).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Detailed message of a network trace operation, e.g. error message in case of failure.
        /// </summary>
        public string Message { get; set; }
    }
}