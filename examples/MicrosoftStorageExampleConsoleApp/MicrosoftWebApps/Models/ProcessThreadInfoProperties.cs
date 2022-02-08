using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// ProcessThreadInfo resource specific properties
    /// </summary>
    public class ProcessThreadInfoProperties
    {
        /// <summary>
        /// Site extension ID.
        /// </summary>
        public int Identifier { get; set; }

        /// <summary>
        /// HRef URI.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Process URI.
        /// </summary>
        public string Process { get; set; }

        /// <summary>
        /// Start address.
        /// </summary>
        public string StartAddress { get; set; }

        /// <summary>
        /// Current thread priority.
        /// </summary>
        public int CurrentPriority { get; set; }

        /// <summary>
        /// Thread priority level.
        /// </summary>
        public string PriorityLevel { get; set; }

        /// <summary>
        /// Base priority.
        /// </summary>
        public int BasePriority { get; set; }

        /// <summary>
        /// Start time.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Total processor time.
        /// </summary>
        public string TotalProcessorTime { get; set; }

        /// <summary>
        /// User processor time.
        /// </summary>
        public string UserProcessorTime { get; set; }

        /// <summary>
        /// Thread state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Wait reason.
        /// </summary>
        public string WaitReason { get; set; }
    }
}