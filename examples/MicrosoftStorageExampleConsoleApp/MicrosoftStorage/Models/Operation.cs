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
        /// Storage REST API operation definition.
        /// </summary>
        public Display Display { get; set; }

        /// <summary>
        /// The origin of operations.
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public OperationProperties Properties { get; set; }
    }
}