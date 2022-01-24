using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The response from the List Usages operation.
    /// </summary>
    public class UsageListResult
    {
        /// <summary>
        /// Gets or sets the list of Storage Resource Usages.
        /// </summary>
        public Usage[] Value { get; set; }
    }
}