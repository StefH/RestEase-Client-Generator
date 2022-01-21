using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class EncryptionScopeProperties
    {
        public string Source { get; set; }

        public string State { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime LastModifiedTime { get; set; }

        public EncryptionScopeKeyVaultProperties KeyVaultProperties { get; set; }

        public bool RequireInfrastructureEncryption { get; set; }
    }
}