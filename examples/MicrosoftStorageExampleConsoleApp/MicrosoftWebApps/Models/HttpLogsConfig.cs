using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Http logs configuration.
    /// </summary>
    public class HttpLogsConfig
    {
        /// <summary>
        /// Http logs to file system configuration.
        /// </summary>
        public FileSystemHttpLogsConfig FileSystem { get; set; }

        /// <summary>
        /// Http logs to azure blob storage configuration.
        /// </summary>
        public AzureBlobStorageHttpLogsConfig AzureBlobStorage { get; set; }
    }
}