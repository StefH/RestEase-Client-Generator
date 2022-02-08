using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Performance monitor sample in a set.
    /// </summary>
    public class PerfMonSample
    {
        /// <summary>
        /// Point in time for which counter was measured.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Name of the server on which the measurement is made.
        /// </summary>
        public string InstanceName { get; set; }

        /// <summary>
        /// Value of counter at a certain time.
        /// </summary>
        public double Value { get; set; }
    }
}