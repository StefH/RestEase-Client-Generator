using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Trigger based on total requests.
    /// </summary>
    public class RequestsBasedTrigger
    {
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