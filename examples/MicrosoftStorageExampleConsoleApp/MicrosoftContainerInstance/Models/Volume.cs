using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The properties of the volume.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class Volume
    {
        /// <summary>
        /// The name of the volume.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The properties of the Azure File volume. Azure File shares are mounted as volumes.
        /// </summary>
        public AzureFileVolume AzureFile { get; set; }

        /// <summary>
        /// The empty directory volume.
        /// </summary>
        public EmptyDirVolume EmptyDir { get; set; }

        /// <summary>
        /// The secret volume.
        /// </summary>
        public Dictionary<string, string > SecretVolume { get; set; }

        /// <summary>
        /// Represents a volume that is populated with the contents of a git repository
        /// </summary>
        public GitRepoVolume GitRepo { get; set; }
    }
}