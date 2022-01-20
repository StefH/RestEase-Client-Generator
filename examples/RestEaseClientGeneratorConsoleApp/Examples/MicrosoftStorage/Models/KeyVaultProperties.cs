using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class KeyVaultProperties
    {
        public string Keyname { get; set; }

        public string Keyversion { get; set; }

        public string Keyvaulturi { get; set; }

        public string CurrentVersionedKeyIdentifier { get; set; }

        public DateTime LastKeyRotationTimestamp { get; set; }
    }
}