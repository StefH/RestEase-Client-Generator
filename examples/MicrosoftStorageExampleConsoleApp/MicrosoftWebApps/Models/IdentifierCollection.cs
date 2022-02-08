using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of identifiers.
    /// </summary>
    public class IdentifierCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public Identifier[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}