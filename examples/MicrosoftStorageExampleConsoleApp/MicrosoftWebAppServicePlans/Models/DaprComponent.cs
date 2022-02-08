using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Dapr component configuration
    /// </summary>
    public class DaprComponent
    {
        /// <summary>
        /// Component name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Component type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Component version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Component metadata
        /// </summary>
        public DaprMetadata[] Metadata { get; set; }
    }
}