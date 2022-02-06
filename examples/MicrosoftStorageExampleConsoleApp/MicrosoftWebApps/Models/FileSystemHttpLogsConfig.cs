using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Http logs to file system configuration.
    /// </summary>
    public class FileSystemHttpLogsConfig
    {
        /// <summary>
        /// Maximum size in megabytes that http log files can use.When reached old log files will be removed to make space for new ones.Value can range between 25 and 100.
        /// </summary>
        public int RetentionInMb { get; set; }

        /// <summary>
        /// Retention in days.Remove files older than X days.0 or lower means no retention.
        /// </summary>
        public int RetentionInDays { get; set; }

        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        public bool Enabled { get; set; }
    }
}