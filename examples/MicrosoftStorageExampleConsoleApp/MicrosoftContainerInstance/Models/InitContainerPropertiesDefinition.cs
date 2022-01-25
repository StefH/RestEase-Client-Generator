using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The init container definition properties.
    /// </summary>
    public class InitContainerPropertiesDefinition
    {
        /// <summary>
        /// The image of the init container.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// The command to execute within the init container in exec form.
        /// </summary>
        public string[] Command { get; set; }

        /// <summary>
        /// The environment variables to set in the init container.
        /// </summary>
        public EnvironmentVariable[] EnvironmentVariables { get; set; }

        /// <summary>
        /// The init container definition properties.
        /// </summary>
        public InitContainerPropertiesDefinitionInstanceView InstanceView { get; set; }

        /// <summary>
        /// The volume mounts available to the init container.
        /// </summary>
        public VolumeMount[] VolumeMounts { get; set; }
    }
}