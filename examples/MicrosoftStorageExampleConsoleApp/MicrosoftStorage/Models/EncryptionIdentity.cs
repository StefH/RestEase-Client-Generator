using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class EncryptionIdentity
    {
        public string UserAssignedIdentity { get; set; }

        public string FederatedIdentityClientId { get; set; }
    }
}