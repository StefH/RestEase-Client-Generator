using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The GitHub action container configuration.
    /// </summary>
    public class GitHubActionContainerConfiguration
    {
        /// <summary>
        /// The server URL for the container registry where the build will be hosted.
        /// </summary>
        public string ServerUrl { get; set; }

        /// <summary>
        /// The image name for the build.
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// The username used to upload the image to the container registry.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password used to upload the image to the container registry.
        /// </summary>
        public string Password { get; set; }
    }
}