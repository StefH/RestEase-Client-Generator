using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// HybridConnectionKey resource specific properties
    /// </summary>
    public class HybridConnectionKeyProperties
    {
        /// <summary>
        /// The name of the send key.
        /// </summary>
        public string SendKeyName { get; set; }

        /// <summary>
        /// The value of the send key.
        /// </summary>
        public string SendKeyValue { get; set; }
    }
}