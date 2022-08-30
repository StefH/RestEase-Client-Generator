using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Common error response for all Azure Resource Manager APIs to return error details for failed operations. (This also follows the OData error response format.).
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// The error detail.
        /// </summary>
        public ErrorDetail Error { get; set; }
    }
}