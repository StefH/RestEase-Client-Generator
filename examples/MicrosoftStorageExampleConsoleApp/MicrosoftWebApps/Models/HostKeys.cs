using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Functions host level keys.
    /// </summary>
    public class HostKeys
    {
        /// <summary>
        /// Secret key.
        /// </summary>
        public string MasterKey { get; set; }

        /// <summary>
        /// Host level function keys.
        /// </summary>
        public Dictionary<string, string> FunctionKeys { get; set; }

        /// <summary>
        /// System keys.
        /// </summary>
        public Dictionary<string, string> SystemKeys { get; set; }
    }
}