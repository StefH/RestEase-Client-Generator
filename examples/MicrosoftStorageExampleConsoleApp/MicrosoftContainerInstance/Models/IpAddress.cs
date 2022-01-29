using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// IP address for the container group.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class IpAddress
    {
        /// <summary>
        /// The list of ports exposed on the container group.
        /// </summary>
        public Port[] Ports { get; set; }

        /// <summary>
        /// Specifies if the IP is exposed to the public internet or private VNET.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The IP exposed to the public internet.
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// The Dns name label for the IP.
        /// </summary>
        public string DnsNameLabel { get; set; }

        /// <summary>
        /// The value representing the security enum.
        /// </summary>
        public string DnsNameLabelReusePolicy { get; set; }

        /// <summary>
        /// The FQDN for the IP.
        /// </summary>
        public string Fqdn { get; set; }
    }
}