using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Http logs to azure blob storage configuration.
    /// </summary>
    public class AzureBlobStorageHttpLogsConfig
    {
        /// <summary>
        /// SAS url to a azure blob container with read/write/list/delete permissions.
        /// </summary>
        public string SasUrl { get; set; }

        /// <summary>
        /// Retention in days.Remove blobs older than X days.0 or lower means no retention.
        /// </summary>
        public int RetentionInDays { get; set; }

        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        public bool Enabled { get; set; }
    }
}