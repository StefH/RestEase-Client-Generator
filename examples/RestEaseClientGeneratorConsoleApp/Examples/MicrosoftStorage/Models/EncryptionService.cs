using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// A service that allows server-side encryption to be used.
    /// </summary>
    public class EncryptionService
    {
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored. Encryption at rest is enabled by default today and cannot be disabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Data is encrypted at rest by default today and cannot be disabled.
        /// </summary>
        public DateTime LastEnabledTime { get; set; }

        /// <summary>
        /// Encryption key type to be used for the encryption service. 'Account' key type implies that an account-scoped encryption key will be used. 'Service' key type implies that a default service key is used.
        /// </summary>
        public string KeyType { get; set; }
    }
}