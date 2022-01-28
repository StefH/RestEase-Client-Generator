using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The encryption settings on the storage account.
    /// </summary>
    public class Encryption
    {
        /// <summary>
        /// A list of services that support encryption.
        /// </summary>
        public EncryptionServices Services { get; set; }

        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive):  Microsoft.Storage, Microsoft.Keyvault
        /// </summary>
        public string KeySource { get; set; }

        /// <summary>
        /// A boolean indicating whether or not the service applies a secondary layer of encryption with platform managed keys for data at rest.
        /// </summary>
        public bool RequireInfrastructureEncryption { get; set; }

        /// <summary>
        /// Properties of key vault.
        /// </summary>
        public KeyVaultProperties Keyvaultproperties { get; set; }

        /// <summary>
        /// Encryption identity for the storage account.
        /// </summary>
        public EncryptionIdentity Identity { get; set; }
    }
}