using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// String dictionary resource.
    /// </summary>
    public class StringDictionary : ProxyOnlyResource
    {
        /// <summary>
        /// Settings.
        /// </summary>
        public Dictionary<string, string> Properties { get; set; }

    }
}