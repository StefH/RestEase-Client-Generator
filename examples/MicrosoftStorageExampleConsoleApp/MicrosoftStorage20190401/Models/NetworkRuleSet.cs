using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    public class NetworkRuleSet
    {
        public string Bypass { get; set; }

        public VirtualNetworkRule[] VirtualNetworkRules { get; set; }

        public IPRule[] IpRules { get; set; }

        public string DefaultAction { get; set; }
    }
}