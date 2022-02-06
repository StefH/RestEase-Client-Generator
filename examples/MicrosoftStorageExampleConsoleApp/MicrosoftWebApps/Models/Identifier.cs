using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// A domain specific resource identifier.
    /// </summary>
    public class Identifier : ProxyOnlyResource
    {
        /// <summary>
        /// Identifier resource specific properties
        /// </summary>
        public IdentifierProperties Properties { get; set; }

    }
}