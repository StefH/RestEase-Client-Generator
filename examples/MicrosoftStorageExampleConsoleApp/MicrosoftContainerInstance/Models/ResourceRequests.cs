using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The resource requests.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class ResourceRequests
    {
        /// <summary>
        /// The memory request in GB of this container instance.
        /// </summary>
        public double MemoryInGB { get; set; }

        /// <summary>
        /// The CPU request of this container instance.
        /// </summary>
        public double Cpu { get; set; }

        /// <summary>
        /// The GPU resource.
        /// </summary>
        public GpuResource Gpu { get; set; }
    }
}