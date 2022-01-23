using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class ResourceLimits
    {
        public double MemoryInGB { get; set; }

        public double Cpu { get; set; }

        public GpuResource Gpu { get; set; }
    }
}