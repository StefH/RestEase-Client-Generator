using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The operation list response that contains all operations for Azure Container Instance service.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class OperationListResult
    {
        /// <summary>
        /// The list of operations.
        /// </summary>
        public Operation[] Value { get; set; }

        /// <summary>
        /// The URI to fetch the next page of operations.
        /// </summary>
        public string NextLink { get; set; }
    }
}