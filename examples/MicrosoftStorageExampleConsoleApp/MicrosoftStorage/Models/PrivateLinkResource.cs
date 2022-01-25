using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// A private link resource
    /// </summary>
    public class PrivateLinkResource : Resource
    {
        /// <summary>
        /// Properties of a private link resource.
        /// </summary>
        public PrivateLinkResourceProperties Properties { get; set; }

    }
}