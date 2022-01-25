using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The resource requirements.
    /// </summary>
    public class ResourceRequirements
    {
        /// <summary>
        /// The resource requests.
        /// </summary>
        public ResourceRequests Requests { get; set; }

        /// <summary>
        /// The resource limits.
        /// </summary>
        public ResourceLimits Limits { get; set; }
    }
}