using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class Capabilities
    {
        public string ResourceType { get; set; }

        public string OsType { get; set; }

        public string Location { get; set; }

        public string IpAddressType { get; set; }

        public string Gpu { get; set; }

        [Newtonsoft.Json.JsonProperty("Capabilities")]
        public Capabilities Capabilities_ { get; set; }
    }
}