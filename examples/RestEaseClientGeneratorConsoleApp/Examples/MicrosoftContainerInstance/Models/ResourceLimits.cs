using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The resource limits.
    /// </summary>
    public class ResourceLimits
    {
        /// <summary>
        /// The memory limit in GB of this container instance.
        /// </summary>
        public double MemoryInGB { get; set; }

        /// <summary>
        /// The CPU limit of this container instance.
        /// </summary>
        public double Cpu { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public GpuResource Gpu { get; set; }
    }
}