using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Configuration of key for data encryption
    /// </summary>
    public class EncryptionProperties
    {
        /// <summary>
        /// Indicates whether or not the encryption is enabled for container registry.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public KeyVaultProperties KeyVaultProperties { get; set; }
    }
}