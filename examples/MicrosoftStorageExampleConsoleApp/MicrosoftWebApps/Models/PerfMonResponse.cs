using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Performance monitor API response.
    /// </summary>
    public class PerfMonResponse
    {
        /// <summary>
        /// The response code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Metric information.
        /// </summary>
        public PerfMonSet Data { get; set; }
    }
}