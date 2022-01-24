using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// An error response from the Container Instance service.
    /// </summary>
    public class CloudErrorBody
    {
        /// <summary>
        /// An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// A message describing the error, intended to be suitable for display in a user interface.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The target of the particular error. For example, the name of the property in error.
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// A list of additional details about the error.
        /// </summary>
        public CloudErrorBody[] Details { get; set; }
    }
}