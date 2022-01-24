using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class Display
    {
        /// <summary>
        /// The name of the provider of the operation.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// The name of the resource type of the operation.
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// The friendly name of the operation.
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// The description of the operation.
        /// </summary>
        public string Description { get; set; }
    }
}