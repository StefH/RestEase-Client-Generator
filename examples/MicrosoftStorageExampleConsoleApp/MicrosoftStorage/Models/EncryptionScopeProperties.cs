using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Properties of the encryption scope.
    /// </summary>
    public class EncryptionScopeProperties
    {
        /// <summary>
        /// The provider for the encryption scope. Possible values (case-insensitive):  Microsoft.Storage, Microsoft.KeyVault.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// The state of the encryption scope. Possible values (case-insensitive):  Enabled, Disabled.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets the creation date and time of the encryption scope in UTC.
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets the last modification date and time of the encryption scope in UTC.
        /// </summary>
        public DateTime LastModifiedTime { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public EncryptionScopeKeyVaultProperties KeyVaultProperties { get; set; }

        /// <summary>
        /// A boolean indicating whether or not the service applies a secondary layer of encryption with platform managed keys for data at rest.
        /// </summary>
        public bool RequireInfrastructureEncryption { get; set; }
    }
}