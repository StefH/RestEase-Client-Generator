using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class IpAddress
    {
        public Port[] Ports { get; set; }

        public string Type { get; set; }

        public string Ip { get; set; }

        public string DnsNameLabel { get; set; }

        public string DnsNameLabelReusePolicy { get; set; }

        public string Fqdn { get; set; }
    }
}