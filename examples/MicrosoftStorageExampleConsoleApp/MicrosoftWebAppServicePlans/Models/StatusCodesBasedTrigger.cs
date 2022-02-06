using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Trigger based on status code.
    /// </summary>
    public class StatusCodesBasedTrigger
    {
        /// <summary>
        /// HTTP status code.
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Request Sub Status.
        /// </summary>
        public int SubStatus { get; set; }

        /// <summary>
        /// Win32 error code.
        /// </summary>
        public int Win32Status { get; set; }

        /// <summary>
        /// Request Count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Time interval.
        /// </summary>
        public string TimeInterval { get; set; }

        /// <summary>
        /// Request Path
        /// </summary>
        public string Path { get; set; }
    }
}