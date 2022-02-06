using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    public class ContainerMemoryStatistics
    {
        public long Usage { get; set; }

        public long MaxUsage { get; set; }

        public long Limit { get; set; }
    }
}