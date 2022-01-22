using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class EncryptionProperties
    {
        public string Status { get; set; }

        public KeyVaultProperties KeyVaultProperties { get; set; }
    }
}