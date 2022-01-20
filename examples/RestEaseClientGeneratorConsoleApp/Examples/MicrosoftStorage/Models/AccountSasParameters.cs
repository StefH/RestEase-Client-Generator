using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class AccountSasParameters
    {
        public string SignedServices { get; set; }

        public string SignedResourceTypes { get; set; }

        public string SignedPermission { get; set; }

        public string SignedIp { get; set; }

        public string SignedProtocol { get; set; }

        public DateTime SignedStart { get; set; }

        public DateTime SignedExpiry { get; set; }

        public string KeyToSign { get; set; }
    }
}