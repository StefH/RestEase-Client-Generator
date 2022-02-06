using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Container App container environment variable.
    /// </summary>
    public class EnvironmentVar
    {
        /// <summary>
        /// Environment variable name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Non-secret environment variable value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Name of the Container App secret from which to pull the environment variable value.
        /// </summary>
        public string SecretRef { get; set; }
    }
}