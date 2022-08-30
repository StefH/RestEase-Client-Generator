using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The key vault properties for the encryption scope. This is a required field if encryption scope 'source' attribute is set to 'Microsoft.KeyVault'.
    /// </summary>
    public class EncryptionScopeKeyVaultProperties
    {
        /// <summary>
        /// The object identifier for a key vault key object. When applied, the encryption scope will use the key referenced by the identifier to enable customer-managed key support on this encryption scope.
        /// </summary>
        public string KeyUri { get; set; }

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