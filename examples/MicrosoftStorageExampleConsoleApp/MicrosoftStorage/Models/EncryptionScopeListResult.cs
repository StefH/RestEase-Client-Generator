using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// List of encryption scopes requested, and if paging is required, a URL to the next page of encryption scopes.
    /// </summary>
    public class EncryptionScopeListResult
    {
        /// <summary>
        /// List of encryption scopes requested.
        /// </summary>
        public EncryptionScope[] Value { get; set; }

        /// <summary>
        /// Request URL that can be used to query next page of encryption scopes. Returned when total number of requested encryption scopes exceeds the maximum page size.
        /// </summary>
        public string NextLink { get; set; }
    }
}