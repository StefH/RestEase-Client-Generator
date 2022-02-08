using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Specification for an App Service Environment to use for this resource.
    /// </summary>
    public class HostingEnvironmentProfile
    {
        /// <summary>
        /// Resource ID of the App Service Environment.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the App Service Environment.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Resource type of the App Service Environment.
        /// </summary>
        public string Type { get; set; }
    }
}