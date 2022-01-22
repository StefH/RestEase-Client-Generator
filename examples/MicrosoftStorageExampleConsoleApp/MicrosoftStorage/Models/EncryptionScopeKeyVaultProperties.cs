using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class EncryptionScopeKeyVaultProperties
    {
        public string KeyUri { get; set; }

        public string CurrentVersionedKeyIdentifier { get; set; }

        public DateTime LastKeyRotationTimestamp { get; set; }
    }
}