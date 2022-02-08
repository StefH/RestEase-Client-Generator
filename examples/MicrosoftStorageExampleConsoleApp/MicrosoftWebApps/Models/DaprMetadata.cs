using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Container App Dapr component metadata.
    /// </summary>
    public class DaprMetadata
    {
        /// <summary>
        /// Metadata property name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Metadata property value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Name of the Container App secret from which to pull the metadata property value.
        /// </summary>
        public string SecretRef { get; set; }
    }
}