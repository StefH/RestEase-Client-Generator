using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Body of the error response returned from the API.
    /// </summary>
    public class ErrorEntity
    {
        /// <summary>
        /// Type of error.
        /// </summary>
        public string ExtendedCode { get; set; }

        /// <summary>
        /// Message template.
        /// </summary>
        public string MessageTemplate { get; set; }

        /// <summary>
        /// Parameters for the template.
        /// </summary>
        public string[] Parameters { get; set; }

        /// <summary>
        /// Inner errors.
        /// </summary>
        public ErrorEntity[] InnerErrors { get; set; }

        /// <summary>
        /// Error Details.
        /// </summary>
        public ErrorEntity[] Details { get; set; }

        /// <summary>
        /// The error target.
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Basic error code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Any details of the error.
        /// </summary>
        public string Message { get; set; }
    }
}