using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The GPU resource.
    /// </summary>
    public class GpuResource
    {
        /// <summary>
        /// The count of the GPU resource.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The SKU of the GPU resource.
        /// </summary>
        public string Sku { get; set; }
    }
}