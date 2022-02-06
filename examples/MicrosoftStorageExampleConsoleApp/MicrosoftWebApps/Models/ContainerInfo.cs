using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    public class ContainerInfo
    {
        public DateTime CurrentTimeStamp { get; set; }

        public DateTime PreviousTimeStamp { get; set; }

        public ContainerCpuStatistics CurrentCpuStats { get; set; }

        public ContainerCpuStatistics PreviousCpuStats { get; set; }

        public ContainerMemoryStatistics MemoryStats { get; set; }

        public string Name { get; set; }

        public string Id { get; set; }

        public ContainerNetworkInterfaceStatistics Eth0 { get; set; }
    }
}