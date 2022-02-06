using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of slot differences.
    /// </summary>
    public class SlotDifferenceCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public SlotDifference[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}