using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Triggers for auto-heal.
    /// </summary>
    public class AutoHealTriggers
    {
        /// <summary>
        /// Trigger based on total requests.
        /// </summary>
        public RequestsBasedTrigger Requests { get; set; }

        /// <summary>
        /// A rule based on private bytes.
        /// </summary>
        public int PrivateBytesInKB { get; set; }

        /// <summary>
        /// A rule based on status codes.
        /// </summary>
        public StatusCodesBasedTrigger[] StatusCodes { get; set; }

        /// <summary>
        /// Trigger based on request execution time.
        /// </summary>
        public SlowRequestsBasedTrigger SlowRequests { get; set; }

        /// <summary>
        /// A rule based on multiple Slow Requests Rule with path
        /// </summary>
        public SlowRequestsBasedTrigger[] SlowRequestsWithPath { get; set; }

        /// <summary>
        /// A rule based on status codes ranges.
        /// </summary>
        public StatusCodesRangeBasedTrigger[] StatusCodesRange { get; set; }
    }
}