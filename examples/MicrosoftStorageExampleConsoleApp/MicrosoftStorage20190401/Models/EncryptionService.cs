using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// A service that allows server-side encryption to be used.
    /// </summary>
    public class EncryptionService
    {
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        public DateTime LastEnabledTime { get; set; }
    }
}