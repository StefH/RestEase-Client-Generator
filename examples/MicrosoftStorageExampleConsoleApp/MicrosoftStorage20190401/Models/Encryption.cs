using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    public class Encryption
    {
        public EncryptionServices Services { get; set; }

        public string KeySource { get; set; }

        public KeyVaultProperties Keyvaultproperties { get; set; }
    }
}