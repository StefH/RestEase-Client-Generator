using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// The CheckNameAvailability operation response.
    /// </summary>
    public class CheckNameAvailabilityResult
    {
        /// <summary>
        /// Gets a boolean value that indicates whether the name is available for you to use. If true, the name is available. If false, the name has already been taken or is invalid and cannot be used.
        /// </summary>
        public bool NameAvailable { get; set; }

        /// <summary>
        /// Gets the reason that a storage account name could not be used. The Reason element is only returned if NameAvailable is false.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Gets an error message explaining the Reason value in more detail.
        /// </summary>
        public string Message { get; set; }
    }
}