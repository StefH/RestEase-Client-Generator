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
        /// not-used
        /// </summary>
        public ResourceRequests Requests { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ResourceLimits Limits { get; set; }
    }
}