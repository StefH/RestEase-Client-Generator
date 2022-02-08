using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of detector responses
    /// </summary>
    public class DetectorResponseCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public DetectorResponse[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}