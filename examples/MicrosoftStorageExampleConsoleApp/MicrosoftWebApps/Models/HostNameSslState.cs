using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// SSL-enabled hostname.
    /// </summary>
    public class HostNameSslState
    {
        /// <summary>
        /// Hostname.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// SSL type.
        /// </summary>
        public string SslState { get; set; }

        /// <summary>
        /// Virtual IP address assigned to the hostname if IP based SSL is enabled.
        /// </summary>
        public string VirtualIP { get; set; }

        /// <summary>
        /// SSL certificate thumbprint.
        /// </summary>
        public string Thumbprint { get; set; }

        /// <summary>
        /// Set to true to update existing hostname.
        /// </summary>
        public bool ToUpdate { get; set; }

        /// <summary>
        /// Indicates whether the hostname is a standard or repository hostname.
        /// </summary>
        public string HostType { get; set; }
    }
}