using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Describes Storage Resource Usage.
    /// </summary>
    public class Usage
    {
        /// <summary>
        /// Gets the unit of measurement.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets the current count of the allocated resources in the subscription.
        /// </summary>
        public int CurrentValue { get; set; }

        /// <summary>
        /// Gets the maximum count of the resources that can be allocated in the subscription.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// The usage names that can be used; currently limited to StorageAccount.
        /// </summary>
        public UsageName Name { get; set; }
    }
}