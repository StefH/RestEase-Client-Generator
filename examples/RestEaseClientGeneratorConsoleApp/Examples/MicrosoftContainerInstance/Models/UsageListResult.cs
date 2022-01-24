using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The response containing the usage data
    /// </summary>
    public class UsageListResult
    {
        /// <summary>
        /// The usage data.
        /// </summary>
        public Usage[] Value { get; set; }
    }
}