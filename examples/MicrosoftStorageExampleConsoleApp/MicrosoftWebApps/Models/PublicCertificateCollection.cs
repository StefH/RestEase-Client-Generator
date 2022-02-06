using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of public certificates
    /// </summary>
    public class PublicCertificateCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public PublicCertificate[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}