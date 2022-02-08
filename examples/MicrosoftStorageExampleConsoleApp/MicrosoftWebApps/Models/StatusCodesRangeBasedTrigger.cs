using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Trigger based on range of status codes.
    /// </summary>
    public class StatusCodesRangeBasedTrigger
    {
        /// <summary>
        /// HTTP status code.
        /// </summary>
        public string StatusCodes { get; set; }

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