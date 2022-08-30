using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// A list of REST API operations supported by an Azure Resource Provider. It contains an URL link to get the next set of results.
    /// </summary>
    public class OperationListResult
    {
        /// <summary>
        /// List of operations supported by the resource provider
        /// </summary>
        public Models.Operation[] Value { get; set; }

        /// <summary>
        /// URL to get the next set of operation list results (if there are any).
        /// </summary>
        public string NextLink { get; set; }
    }
}