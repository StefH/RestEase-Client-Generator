using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Specification for a Kubernetes Environment to use for this resource.
    /// </summary>
    public class KubeEnvironmentProfile
    {
        /// <summary>
        /// Resource ID of the Kubernetes Environment.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the Kubernetes Environment.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Resource type of the Kubernetes Environment.
        /// </summary>
        public string Type { get; set; }
    }
}