using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Error model.
    /// </summary>
    public class DefaultErrorResponseError
    {
        /// <summary>
        /// Standardized string to programmatically identify the error.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Detailed error description and debugging information.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Detailed error description and debugging information.
        /// </summary>
        public string Target { get; set; }

        public DefaultErrorResponseErrorDetails Details { get; set; }

        /// <summary>
        /// More information to debug error.
        /// </summary>
        public string Innererror { get; set; }
    }
}