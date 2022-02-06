using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// PublicCertificate resource specific properties
    /// </summary>
    public class PublicCertificateProperties
    {
        /// <summary>
        /// Public Certificate byte array
        /// </summary>
        public byte[] Blob { get; set; }

        /// <summary>
        /// Public Certificate Location
        /// </summary>
        public string PublicCertificateLocation { get; set; }

        /// <summary>
        /// Certificate Thumbprint
        /// </summary>
        public string Thumbprint { get; set; }
    }
}