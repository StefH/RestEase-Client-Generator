using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// The response from the List Storage SKUs operation.
    /// </summary>
    public class StorageSkuListResult
    {
        /// <summary>
        /// Get the list result of storage SKUs and their properties.
        /// </summary>
        public Sku[] Value { get; set; }
    }
}