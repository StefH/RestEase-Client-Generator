using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class EncryptionProperties
    {
        public string Status { get; set; }

        public KeyVaultProperties KeyVaultProperties { get; set; }
    }
}