using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The response containing list of capabilities.
    /// </summary>
    public class CapabilitiesListResult
    {
        /// <summary>
        /// The list of capabilities.
        /// </summary>
        public Capabilities[] Value { get; set; }

        /// <summary>
        /// The URI to fetch the next page of capabilities.
        /// </summary>
        public string NextLink { get; set; }
    }
}