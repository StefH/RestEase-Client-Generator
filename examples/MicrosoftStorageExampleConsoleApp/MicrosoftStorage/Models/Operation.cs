using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Storage REST API operation definition.
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Operation name: {provider}/{resource}/{operation}
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Display metadata associated with the operation.
        /// </summary>
        public OperationDisplay Display { get; set; }

        /// <summary>
        /// The origin of operations.
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// Properties of operation, include metric specifications.
        /// </summary>
        public OperationProperties Properties { get; set; }
    }
}