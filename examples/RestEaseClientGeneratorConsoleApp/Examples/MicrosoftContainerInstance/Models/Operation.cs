using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// An operation for Azure Container Instance service.
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// The name of the operation.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An operation for Azure Container Instance service.
        /// </summary>
        public Display Display { get; set; }

        /// <summary>
        /// An operation for Azure Container Instance service.
        /// </summary>
        public Properties Properties { get; set; }

        /// <summary>
        /// The intended executor of the operation.
        /// </summary>
        public string Origin { get; set; }
    }
}