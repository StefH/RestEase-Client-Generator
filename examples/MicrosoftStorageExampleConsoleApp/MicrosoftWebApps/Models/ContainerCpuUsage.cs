using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    public class ContainerCpuUsage
    {
        public long TotalUsage { get; set; }

        public long[] PerCpuUsage { get; set; }

        public long KernelModeUsage { get; set; }

        public long UserModeUsage { get; set; }
    }
}