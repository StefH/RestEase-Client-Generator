using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Custom action to be executedwhen an auto heal rule is triggered.
    /// </summary>
    public class AutoHealCustomAction
    {
        /// <summary>
        /// Executable to be run.
        /// </summary>
        public string Exe { get; set; }

        /// <summary>
        /// Parameters for the executable.
        /// </summary>
        public string Parameters { get; set; }
    }
}