using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The properties of the Azure File volume. Azure File shares are mounted as volumes.
    /// </summary>
    public class AzureFileVolume
    {
        /// <summary>
        /// The name of the Azure File share to be mounted as a volume.
        /// </summary>
        public string ShareName { get; set; }

        /// <summary>
        /// The flag indicating whether the Azure File shared mounted as a volume is read-only.
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// The name of the storage account that contains the Azure File share.
        /// </summary>
        public string StorageAccountName { get; set; }

        /// <summary>
        /// The storage account access key used to access the Azure File share.
        /// </summary>
        public string StorageAccountKey { get; set; }
    }
}