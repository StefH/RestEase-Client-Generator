using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class LocalUserProperties
    {
        public PermissionScope[] PermissionScopes { get; set; }

        public string HomeDirectory { get; set; }

        public SshPublicKey[] SshAuthorizedKeys { get; set; }

        public string Sid { get; set; }

        public bool HasSharedKey { get; set; }

        public bool HasSshKey { get; set; }

        public bool HasSshPassword { get; set; }
    }
}