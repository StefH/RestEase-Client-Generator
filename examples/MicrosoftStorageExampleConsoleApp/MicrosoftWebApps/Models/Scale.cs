using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Container App scaling configurations.
    /// </summary>
    public class Scale
    {
        /// <summary>
        /// Optional. Minimum number of container replicas.
        /// </summary>
        public int MinReplicas { get; set; }

        /// <summary>
        /// Optional. Maximum number of container replicas. Defaults to 10 if not set.
        /// </summary>
        public int MaxReplicas { get; set; }

        /// <summary>
        /// Scaling rules.
        /// </summary>
        public ScaleRule[] Rules { get; set; }
    }
}