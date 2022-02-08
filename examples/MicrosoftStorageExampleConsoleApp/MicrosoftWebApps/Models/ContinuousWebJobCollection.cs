using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of Kudu continuous web job information elements.
    /// </summary>
    public class ContinuousWebJobCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public ContinuousWebJob[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}