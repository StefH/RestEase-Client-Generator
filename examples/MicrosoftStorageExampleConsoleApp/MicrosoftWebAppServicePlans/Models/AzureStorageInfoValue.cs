using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Azure Files or Blob Storage access information value for dictionary storage.
    /// </summary>
    public class AzureStorageInfoValue
    {
        /// <summary>
        /// Type of storage.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Name of the storage account.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Name of the file share (container name, for Blob storage).
        /// </summary>
        public string ShareName { get; set; }

        /// <summary>
        /// Access key for the storage account.
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Path to mount the storage within the site's runtime environment.
        /// </summary>
        public string MountPath { get; set; }

        /// <summary>
        /// State of the storage account.
        /// </summary>
        public string State { get; set; }
    }
}