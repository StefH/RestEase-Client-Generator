using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Function secrets.
    /// </summary>
    public class FunctionSecrets
    {
        /// <summary>
        /// Secret key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Trigger URL.
        /// </summary>
        public string TriggerUrl { get; set; }
    }
}