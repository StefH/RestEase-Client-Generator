using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// SiteSourceControl resource specific properties
    /// </summary>
    public class SiteSourceControlProperties
    {
        /// <summary>
        /// Repository or source control URL.
        /// </summary>
        public string RepoUrl { get; set; }

        /// <summary>
        /// Name of branch to use for deployment.
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// true to limit to manual integration; false to enable continuous integration (which configures webhooks into online repos like GitHub).
        /// </summary>
        public bool IsManualIntegration { get; set; }

        /// <summary>
        /// true if this is deployed via GitHub action.
        /// </summary>
        public bool IsGitHubAction { get; set; }

        /// <summary>
        /// true to enable deployment rollback; otherwise, false.
        /// </summary>
        public bool DeploymentRollbackEnabled { get; set; }

        /// <summary>
        /// true for a Mercurial repository; false for a Git repository.
        /// </summary>
        public bool IsMercurial { get; set; }

        /// <summary>
        /// The GitHub action configuration.
        /// </summary>
        public GitHubActionConfiguration GitHubActionConfiguration { get; set; }
    }
}