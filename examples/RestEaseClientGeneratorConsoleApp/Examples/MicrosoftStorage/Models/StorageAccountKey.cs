using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// An access key for the storage account.
    /// </summary>
    public class StorageAccountKey
    {
        /// <summary>
        /// Name of the key.
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// Base 64-encoded value of the key.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Permissions for the key -- read-only or full permissions.
        /// </summary>
        public string Permissions { get; set; }

        /// <summary>
        /// Creation time of the key, in round trip date format.
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}