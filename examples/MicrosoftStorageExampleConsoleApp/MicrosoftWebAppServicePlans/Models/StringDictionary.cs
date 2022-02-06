using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
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