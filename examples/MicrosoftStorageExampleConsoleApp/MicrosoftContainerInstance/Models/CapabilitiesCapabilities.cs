using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The supported capabilities.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class CapabilitiesCapabilities
    {
        /// <summary>
        /// The maximum allowed memory request in GB.
        /// </summary>
        public double MaxMemoryInGB { get; set; }

        /// <summary>
        /// The maximum allowed CPU request in cores.
        /// </summary>
        public double MaxCpu { get; set; }

        /// <summary>
        /// The maximum allowed GPU count.
        /// </summary>
        public double MaxGpuCount { get; set; }
    }
}