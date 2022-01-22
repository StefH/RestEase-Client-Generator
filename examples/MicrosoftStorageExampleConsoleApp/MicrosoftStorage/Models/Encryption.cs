using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class Encryption
    {
        public EncryptionServices Services { get; set; }

        public string KeySource { get; set; }

        public bool RequireInfrastructureEncryption { get; set; }

        public KeyVaultProperties Keyvaultproperties { get; set; }

        public EncryptionIdentity Identity { get; set; }
    }
}