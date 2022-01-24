using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The check availability result.
    /// </summary>
    public class CheckNameAvailabilityResponse
    {
        /// <summary>
        /// Indicates if the resource name is available.
        /// </summary>
        public bool NameAvailable { get; set; }

        /// <summary>
        /// The reason why the given name is not available.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Detailed reason why the given name is available.
        /// </summary>
        public string Message { get; set; }
    }
}