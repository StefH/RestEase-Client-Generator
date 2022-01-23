using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// A list of private link resources
    /// </summary>
    public class PrivateLinkResourceListResult
    {
        /// <summary>
        /// Array of private link resources
        /// </summary>
        public PrivateLinkResource[] Value { get; set; }
    }
}