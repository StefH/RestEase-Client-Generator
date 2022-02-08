using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// TriggeredJobHistory resource specific properties
    /// </summary>
    public class TriggeredJobHistoryProperties
    {
        /// <summary>
        /// List of triggered web job runs.
        /// </summary>
        public TriggeredJobRun[] Runs { get; set; }
    }
}