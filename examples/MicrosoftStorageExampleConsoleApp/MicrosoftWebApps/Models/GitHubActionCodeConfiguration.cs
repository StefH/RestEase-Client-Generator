using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The GitHub action code configuration.
    /// </summary>
    public class GitHubActionCodeConfiguration
    {
        /// <summary>
        /// Runtime stack is used to determine the workflow file content for code base apps.
        /// </summary>
        public string RuntimeStack { get; set; }

        /// <summary>
        /// Runtime version is used to determine what build version to set in the workflow file.
        /// </summary>
        public string RuntimeVersion { get; set; }
    }
}