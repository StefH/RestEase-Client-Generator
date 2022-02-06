using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// A private link resource
    /// </summary>
    public class PrivateLinkResource
    {
        public string Id { get; set; }

        /// <summary>
        /// Name of a private link resource
        /// </summary>
        public string Name { get; set; }

        public string Type { get; set; }

        /// <summary>
        /// Properties of a private link resource
        /// </summary>
        public PrivateLinkResourceProperties Properties { get; set; }
    }
}