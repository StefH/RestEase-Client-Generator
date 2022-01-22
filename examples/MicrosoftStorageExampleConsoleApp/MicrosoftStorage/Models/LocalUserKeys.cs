using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class LocalUserKeys
    {
        public SshPublicKey[] SshAuthorizedKeys { get; set; }

        public string SharedKey { get; set; }
    }
}