using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// MSDeployStatus resource specific properties
    /// </summary>
    public class MSDeployStatusProperties
    {
        /// <summary>
        /// Username of deployer
        /// </summary>
        public string Deployer { get; set; }

        /// <summary>
        /// Provisioning state
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Start time of deploy operation
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End time of deploy operation
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Whether the deployment operation has completed
        /// </summary>
        public bool Complete { get; set; }
    }
}