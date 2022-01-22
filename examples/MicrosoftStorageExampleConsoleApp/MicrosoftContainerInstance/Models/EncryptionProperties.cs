using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class EncryptionProperties
    {
        public string VaultBaseUrl { get; set; }

        public string KeyName { get; set; }

        public string KeyVersion { get; set; }
    }
}