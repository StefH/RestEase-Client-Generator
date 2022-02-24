using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Detailed errors.
    /// </summary>
    public class DefaultErrorResponseErrorDetails
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
    }
}