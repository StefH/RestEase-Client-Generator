using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Common error response for all Azure Resource Manager APIs to return error details for failed operations. (This also follows the OData error response format.)
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// The error code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The error target.
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// The error details.
        /// </summary>
        public ErrorResponse[] Details { get; set; }

        /// <summary>
        /// The error additional info.
        /// </summary>
        public ErrorAdditionalInfo[] AdditionalInfo { get; set; }
    }
}