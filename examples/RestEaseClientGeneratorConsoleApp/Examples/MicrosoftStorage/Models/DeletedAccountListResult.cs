using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The response from the List Deleted Accounts operation.
    /// </summary>
    public class DeletedAccountListResult
    {
        /// <summary>
        /// Gets the list of deleted accounts and their properties.
        /// </summary>
        public DeletedAccount[] Value { get; set; }

        /// <summary>
        /// Request URL that can be used to query next page of deleted accounts. Returned when total number of requested deleted accounts exceed maximum page size.
        /// </summary>
        public string NextLink { get; set; }
    }
}