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
        /// not-used
        /// </summary>
        public EncryptionService Blob { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public EncryptionService File { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public EncryptionService Table { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public EncryptionService Queue { get; set; }
    }
}