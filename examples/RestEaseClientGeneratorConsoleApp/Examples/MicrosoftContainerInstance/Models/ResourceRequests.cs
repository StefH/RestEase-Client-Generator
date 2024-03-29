using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The resource requests.
    /// </summary>
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
        /// not-used
        /// </summary>
        public GpuResource Gpu { get; set; }
    }
}