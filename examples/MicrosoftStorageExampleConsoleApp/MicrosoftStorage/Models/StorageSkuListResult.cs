using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The response from the List Storage SKUs operation.
    /// </summary>
    public class StorageSkuListResult
    {
        /// <summary>
        /// Get the list result of storage SKUs and their properties.
        /// </summary>
        public SkuInformation[] Value { get; set; }
    }
}