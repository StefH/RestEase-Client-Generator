using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The GitHub action configuration.
    /// </summary>
    public class GitHubActionConfiguration
    {
        /// <summary>
        /// The GitHub action code configuration.
        /// </summary>
        public GitHubActionCodeConfiguration CodeConfiguration { get; set; }

        /// <summary>
        /// The GitHub action container configuration.
        /// </summary>
        public GitHubActionContainerConfiguration ContainerConfiguration { get; set; }

        /// <summary>
        /// This will help determine the workflow configuration to select.
        /// </summary>
        public bool IsLinux { get; set; }

        /// <summary>
        /// Workflow option to determine whether the workflow file should be generated and written to the repository.
        /// </summary>
        public bool GenerateWorkflowFile { get; set; }
    }
}