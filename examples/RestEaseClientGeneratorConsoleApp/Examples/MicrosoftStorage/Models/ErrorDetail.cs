using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The error detail.
    /// </summary>
    public class ErrorDetail
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
        public ErrorDetail[] Details { get; set; }

        /// <summary>
        /// The error additional info.
        /// </summary>
        public ErrorAdditionalInfo[] AdditionalInfo { get; set; }
    }
}