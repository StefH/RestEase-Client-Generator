using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Deployment resource specific properties
    /// </summary>
    public class DeploymentProperties
    {
        /// <summary>
        /// Deployment status.
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Details about deployment status.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Who authored the deployment.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Who performed the deployment.
        /// </summary>
        public string Deployer { get; set; }

        /// <summary>
        /// Author email.
        /// </summary>
        public string AuthorEmail { get; set; }

        /// <summary>
        /// Start time.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End time.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// True if deployment is currently active, false if completed and null if not started.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Details on deployment.
        /// </summary>
        public string Details { get; set; }
    }
}