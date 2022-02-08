using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of Kudu process information elements.
    /// </summary>
    public class ProcessInfoCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public ProcessInfo[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}