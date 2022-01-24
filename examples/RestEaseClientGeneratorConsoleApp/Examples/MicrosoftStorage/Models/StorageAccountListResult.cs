using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The response from the List Storage Accounts operation.
    /// </summary>
    public class StorageAccountListResult
    {
        /// <summary>
        /// Gets the list of storage accounts and their properties.
        /// </summary>
        public StorageAccount[] Value { get; set; }

        /// <summary>
        /// Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size.
        /// </summary>
        public string NextLink { get; set; }
    }
}