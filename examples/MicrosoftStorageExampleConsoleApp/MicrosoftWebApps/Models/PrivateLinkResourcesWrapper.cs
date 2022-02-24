using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Wrapper for a collection of private link resources
    /// </summary>
    public class PrivateLinkResourcesWrapper
    {
        /// <summary>
        /// A private link resource
        /// </summary>
        public PrivateLinkResource[] Value { get; set; }
    }
}