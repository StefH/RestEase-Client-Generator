using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// HostNameBinding resource specific properties
    /// </summary>
    public class HostNameBindingProperties
    {
        /// <summary>
        /// App Service app name.
        /// </summary>
        public string SiteName { get; set; }

        /// <summary>
        /// Fully qualified ARM domain resource URI.
        /// </summary>
        public string DomainId { get; set; }

        /// <summary>
        /// Azure resource name.
        /// </summary>
        public string AzureResourceName { get; set; }

        /// <summary>
        /// Azure resource type.
        /// </summary>
        public string AzureResourceType { get; set; }

        /// <summary>
        /// Custom DNS record type.
        /// </summary>
        public string CustomHostNameDnsRecordType { get; set; }

        /// <summary>
        /// Hostname type.
        /// </summary>
        public string HostNameType { get; set; }

        /// <summary>
        /// SSL type
        /// </summary>
        public string SslState { get; set; }

        /// <summary>
        /// SSL certificate thumbprint
        /// </summary>
        public string Thumbprint { get; set; }

        /// <summary>
        /// Virtual IP address assigned to the hostname if IP based SSL is enabled.
        /// </summary>
        public string VirtualIP { get; set; }
    }
}