using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Triggered Web Job Run Information.
    /// </summary>
    public class TriggeredJobRun
    {
        /// <summary>
        /// Job ID.
        /// </summary>
        public string WebJobId { get; set; }

        /// <summary>
        /// Job name.
        /// </summary>
        public string WebJobName { get; set; }

        /// <summary>
        /// Job status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Start time.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End time.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Job duration.
        /// </summary>
        public string Duration { get; set; }

        /// <summary>
        /// Output URL.
        /// </summary>
        public string OutputUrl { get; set; }

        /// <summary>
        /// Error URL.
        /// </summary>
        public string ErrorUrl { get; set; }

        /// <summary>
        /// Job URL.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Job name.
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// Job trigger.
        /// </summary>
        public string Trigger { get; set; }
    }
}