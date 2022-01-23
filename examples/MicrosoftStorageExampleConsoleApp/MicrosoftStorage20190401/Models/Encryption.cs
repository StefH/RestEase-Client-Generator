using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// The encryption settings on the storage account.
    /// </summary>
    public class Encryption
    {
        /// <summary>
        /// not-used
        /// </summary>
        public EncryptionServices Services { get; set; }

        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive):  Microsoft.Storage, Microsoft.Keyvault
        /// </summary>
        public string KeySource { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public KeyVaultProperties Keyvaultproperties { get; set; }
    }
}