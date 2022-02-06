using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of Kudu thread information elements.
    /// </summary>
    public class ProcessModuleInfoCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public ProcessModuleInfo[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}