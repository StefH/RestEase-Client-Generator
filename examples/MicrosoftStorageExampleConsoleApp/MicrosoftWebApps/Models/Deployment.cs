using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// User credentials used for publishing activity.
    /// </summary>
    public class Deployment : ProxyOnlyResource
    {
        /// <summary>
        /// Deployment resource specific properties
        /// </summary>
        public DeploymentProperties Properties { get; set; }

    }
}