using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Application logs azure blob storage configuration.
    /// </summary>
    public class AzureBlobStorageApplicationLogsConfig
    {
        /// <summary>
        /// Log level.
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// SAS url to a azure blob container with read/write/list/delete permissions.
        /// </summary>
        public string SasUrl { get; set; }

        /// <summary>
        /// Retention in days.Remove blobs older than X days.0 or lower means no retention.
        /// </summary>
        public int RetentionInDays { get; set; }
    }
}