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
        /// not-used
        /// </summary>
        public ErrorResponseBody Error { get; set; }
    }
}