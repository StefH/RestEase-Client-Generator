using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The properties of the volume.
    /// </summary>
    public class Volume
    {
        /// <summary>
        /// The name of the volume.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public AzureFileVolume AzureFile { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public EmptyDirVolume EmptyDir { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public SecretVolume Secret { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public GitRepoVolume GitRepo { get; set; }
    }
}