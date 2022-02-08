using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of Azure resource manager operation metadata.
    /// </summary>
    public class CsmOperationCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public CsmOperationDescription[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}