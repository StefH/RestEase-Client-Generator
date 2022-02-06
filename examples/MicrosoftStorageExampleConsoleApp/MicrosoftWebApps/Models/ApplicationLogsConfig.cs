using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Application logs configuration.
    /// </summary>
    public class ApplicationLogsConfig
    {
        /// <summary>
        /// Application logs to file system configuration.
        /// </summary>
        public FileSystemApplicationLogsConfig FileSystem { get; set; }

        /// <summary>
        /// Application logs to Azure table storage configuration.
        /// </summary>
        public AzureTableStorageApplicationLogsConfig AzureTableStorage { get; set; }

        /// <summary>
        /// Application logs azure blob storage configuration.
        /// </summary>
        public AzureBlobStorageApplicationLogsConfig AzureBlobStorage { get; set; }
    }
}