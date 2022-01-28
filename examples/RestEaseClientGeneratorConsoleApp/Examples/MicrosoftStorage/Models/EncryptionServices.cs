using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// A list of services that support encryption.
    /// </summary>
    public class EncryptionServices
    {
        /// <summary>
        /// A service that allows server-side encryption to be used.
        /// </summary>
        public EncryptionService Blob { get; set; }

        /// <summary>
        /// A service that allows server-side encryption to be used.
        /// </summary>
        public EncryptionService File { get; set; }

        /// <summary>
        /// A service that allows server-side encryption to be used.
        /// </summary>
        public EncryptionService Table { get; set; }

        /// <summary>
        /// A service that allows server-side encryption to be used.
        /// </summary>
        public EncryptionService Queue { get; set; }
    }
}