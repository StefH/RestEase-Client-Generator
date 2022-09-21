using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Result of the request to list Storage operations. It contains a list of operations and a URL link to get the next set of results.
    /// </summary>
    public class OperationListResult
    {
        /// <summary>
        /// List of Storage operations supported by the Storage resource provider.
        /// </summary>
        public Models.Operation[] Value { get; set; }
    }
}