using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of performance monitor counters.
    /// </summary>
    public class PerfMonCounterCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public PerfMonResponse[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}