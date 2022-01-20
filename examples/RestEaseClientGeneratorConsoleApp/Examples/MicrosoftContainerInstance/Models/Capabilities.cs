using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class Capabilities
    {
        public string ResourceType { get; set; }

        public string OsType { get; set; }

        public string Location { get; set; }

        public string IpAddressType { get; set; }

        public string Gpu { get; set; }

        [Newtonsoft.Json.JsonProperty("Capabilities")]
        public object Capabilities_ { get; set; }
    }
}