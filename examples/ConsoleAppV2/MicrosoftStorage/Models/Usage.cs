using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
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
        public System.Int32 CurrentValue { get; set; }

        /// <summary>
        /// Gets the maximum count of the resources that can be allocated in the subscription.
        /// </summary>
        public System.Int32 Limit { get; set; }

        /// <summary>
        /// The usage names that can be used; currently limited to StorageAccount.
        /// </summary>
        public UsageName Name { get; set; }
    }
}