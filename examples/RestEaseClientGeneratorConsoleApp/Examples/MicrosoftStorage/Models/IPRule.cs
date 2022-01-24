using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// IP rule with specific IP or IP range in CIDR format.
    /// </summary>
    public class IPRule
    {
        /// <summary>
        /// Specifies the IP or IP range in CIDR format. Only IPV4 address is allowed.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The action of IP ACL rule.
        /// </summary>
        public string Action { get; set; }
    }
}