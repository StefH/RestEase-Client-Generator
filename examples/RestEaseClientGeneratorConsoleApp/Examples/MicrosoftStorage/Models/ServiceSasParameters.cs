using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class ServiceSasParameters
    {
        public string CanonicalizedResource { get; set; }

        public string SignedResource { get; set; }

        public string SignedPermission { get; set; }

        public string SignedIp { get; set; }

        public string SignedProtocol { get; set; }

        public DateTime SignedStart { get; set; }

        public DateTime SignedExpiry { get; set; }

        public string SignedIdentifier { get; set; }

        public string StartPk { get; set; }

        public string EndPk { get; set; }

        public string StartRk { get; set; }

        public string EndRk { get; set; }

        public string KeyToSign { get; set; }

        public string Rscc { get; set; }

        public string Rscd { get; set; }

        public string Rsce { get; set; }

        public string Rscl { get; set; }

        public string Rsct { get; set; }
    }
}