using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// List of private endpoint connection associated with the specified storage account
    /// </summary>
    public class PrivateEndpointConnectionListResult
    {
        /// <summary>
        /// Array of private endpoint connections
        /// </summary>
        public PrivateEndpointConnection[] Value { get; set; }
    }
}