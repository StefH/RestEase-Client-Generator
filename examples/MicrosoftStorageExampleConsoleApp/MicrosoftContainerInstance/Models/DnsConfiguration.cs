using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class DnsConfiguration
    {
        public string[] NameServers { get; set; }

        public string SearchDomains { get; set; }

        public string Options { get; set; }
    }
}