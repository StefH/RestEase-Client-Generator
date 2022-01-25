using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
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
        /// The display information of the operation.
        /// </summary>
        public OperationDisplay Display { get; set; }

        /// <summary>
        /// The additional properties.
        /// </summary>
        public OperationProperties Properties { get; set; }

        /// <summary>
        /// The intended executor of the operation.
        /// </summary>
        public string Origin { get; set; }
    }
}