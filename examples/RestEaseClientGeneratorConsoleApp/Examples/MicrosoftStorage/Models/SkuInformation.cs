using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class SkuInformation
    {
        public string Name { get; set; }

        public string Tier { get; set; }

        public string ResourceType { get; set; }

        public string Kind { get; set; }

        public string[] Locations { get; set; }

        public object[] Capabilities { get; set; }

        public object[] Restrictions { get; set; }
    }
}