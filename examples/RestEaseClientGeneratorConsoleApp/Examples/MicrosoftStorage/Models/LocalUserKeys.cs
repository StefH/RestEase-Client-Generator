using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class LocalUserKeys
    {
        public SshPublicKey[] SshAuthorizedKeys { get; set; }

        public string SharedKey { get; set; }
    }
}