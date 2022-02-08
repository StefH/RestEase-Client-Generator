using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Trigger based on request execution time.
    /// </summary>
    public class SlowRequestsBasedTrigger
    {
        /// <summary>
        /// Time taken.
        /// </summary>
        public string TimeTaken { get; set; }

        /// <summary>
        /// Request Path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Request Count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Time interval.
        /// </summary>
        public string TimeInterval { get; set; }
    }
}