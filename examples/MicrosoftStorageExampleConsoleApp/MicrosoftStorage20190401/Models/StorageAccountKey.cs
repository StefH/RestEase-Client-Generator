using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
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
    }
}