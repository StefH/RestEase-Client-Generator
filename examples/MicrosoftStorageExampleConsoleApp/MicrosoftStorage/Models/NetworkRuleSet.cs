using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class NetworkRuleSet
    {
        public string Bypass { get; set; }

        public object[] ResourceAccessRules { get; set; }

        public object[] VirtualNetworkRules { get; set; }

        public object[] IpRules { get; set; }

        public string DefaultAction { get; set; }
    }
}