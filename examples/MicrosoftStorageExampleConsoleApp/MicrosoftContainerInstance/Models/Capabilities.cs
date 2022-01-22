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

        public double MaxMemoryInGB { get; set; }

        public double MaxCpu { get; set; }

        public double MaxGpuCount { get; set; }
    }
}