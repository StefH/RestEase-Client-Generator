using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Properties of key vault.
    /// </summary>
    public class KeyVaultProperties
    {
        /// <summary>
        /// The name of KeyVault key.
        /// </summary>
        public string Keyname { get; set; }

        /// <summary>
        /// The version of KeyVault key.
        /// </summary>
        public string Keyversion { get; set; }

        /// <summary>
        /// The Uri of KeyVault.
        /// </summary>
        public string Keyvaulturi { get; set; }

        /// <summary>
        /// The object identifier of the current versioned Key Vault Key in use.
        /// </summary>
        public string CurrentVersionedKeyIdentifier { get; set; }

        /// <summary>
        /// Timestamp of last rotation of the Key Vault Key.
        /// </summary>
        public DateTime LastKeyRotationTimestamp { get; set; }
    }
}