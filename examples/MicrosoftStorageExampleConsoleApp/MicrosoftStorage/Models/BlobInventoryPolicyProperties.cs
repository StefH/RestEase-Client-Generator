using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The storage account blob inventory policy properties.
    /// </summary>
    public class BlobInventoryPolicyProperties
    {
        /// <summary>
        /// Returns the last modified date and time of the blob inventory policy.
        /// </summary>
        public DateTime LastModifiedTime { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public BlobInventoryPolicySchema Policy { get; set; }
    }
}