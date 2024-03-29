using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// A single usage result
    /// </summary>
    public class Usage
    {
        /// <summary>
        /// Unit of the usage result
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// The current usage of the resource
        /// </summary>
        public int CurrentValue { get; set; }

        /// <summary>
        /// The maximum permitted usage of the resource.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// A single usage result
        /// </summary>
        public Name Name { get; set; }
    }
}