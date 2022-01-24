using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// DNS configuration for the container group.
    /// </summary>
    public class DnsConfiguration
    {
        /// <summary>
        /// The DNS servers for the container group.
        /// </summary>
        public string[] NameServers { get; set; }

        /// <summary>
        /// The DNS search domains for hostname lookup in the container group.
        /// </summary>
        public string SearchDomains { get; set; }

        /// <summary>
        /// The DNS options for the container group.
        /// </summary>
        public string Options { get; set; }
    }
}