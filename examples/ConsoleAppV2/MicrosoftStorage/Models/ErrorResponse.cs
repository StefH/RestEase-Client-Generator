using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// An error response from the storage resource provider.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Error response body contract.
        /// </summary>
        public ErrorResponseBody Error { get; set; }
    }
}