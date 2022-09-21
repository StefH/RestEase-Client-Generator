using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Display metadata associated with the operation.
    /// </summary>
    public class Display
    {
        /// <summary>
        /// Service provider: Microsoft Storage.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Resource on which the operation is performed etc.
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// Type of operation: get, read, delete, etc.
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// Description of the operation.
        /// </summary>
        public string Description { get; set; }
    }
}