using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The check availability request body.
    /// </summary>
    public class CheckNameAvailabilityRequest
    {
        /// <summary>
        /// The name of the resource for which availability needs to be checked.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The resource type.
        /// </summary>
        public string Type { get; set; }
    }
}