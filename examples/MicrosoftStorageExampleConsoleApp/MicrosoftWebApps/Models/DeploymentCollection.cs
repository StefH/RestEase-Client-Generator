using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of app deployments.
    /// </summary>
    public class DeploymentCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public Deployment[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}