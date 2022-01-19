using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class ResourceRequests
    {
        public double MemoryInGB { get; set; }

        public double Cpu { get; set; }

        public GpuResource Gpu { get; set; }
    }
}
