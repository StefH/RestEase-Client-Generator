using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    public class ContainerCpuStatistics
    {
        public ContainerCpuUsage CpuUsage { get; set; }

        public long SystemCpuUsage { get; set; }

        public int OnlineCpuCount { get; set; }

        public ContainerThrottlingData ThrottlingData { get; set; }
    }
}