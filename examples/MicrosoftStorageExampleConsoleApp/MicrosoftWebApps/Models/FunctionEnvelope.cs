using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Function information.
    /// </summary>
    public class FunctionEnvelope : ProxyOnlyResource
    {
        /// <summary>
        /// FunctionEnvelope resource specific properties
        /// </summary>
        public FunctionEnvelopeProperties Properties { get; set; }

    }
}