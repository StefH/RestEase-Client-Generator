using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Metric information.
    /// </summary>
    public class PerfMonSet
    {
        /// <summary>
        /// Unique key name of the counter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Start time of the period.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End time of the period.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Presented time grain.
        /// </summary>
        public string TimeGrain { get; set; }

        /// <summary>
        /// Collection of workers that are active during this time.
        /// </summary>
        public PerfMonSample[] Values { get; set; }
    }
}