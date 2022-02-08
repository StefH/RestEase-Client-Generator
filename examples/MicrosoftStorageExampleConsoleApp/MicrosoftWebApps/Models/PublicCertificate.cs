using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Public certificate object
    /// </summary>
    public class PublicCertificate : ProxyOnlyResource
    {
        /// <summary>
        /// PublicCertificate resource specific properties
        /// </summary>
        public PublicCertificateProperties Properties { get; set; }

    }
}