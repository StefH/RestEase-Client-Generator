using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of Kudu function information elements.
    /// </summary>
    public class FunctionEnvelopeCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public FunctionEnvelope[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}