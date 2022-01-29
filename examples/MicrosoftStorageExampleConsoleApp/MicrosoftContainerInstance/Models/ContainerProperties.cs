using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The container instance properties.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class ContainerProperties
    {
        /// <summary>
        /// The name of the image used to create the container instance.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// The commands to execute within the container instance in exec form.
        /// </summary>
        public string[] Command { get; set; }

        /// <summary>
        /// The exposed ports on the container instance.
        /// </summary>
        public ContainerPort[] Ports { get; set; }

        /// <summary>
        /// The environment variables to set in the container instance.
        /// </summary>
        public EnvironmentVariable[] EnvironmentVariables { get; set; }

        /// <summary>
        /// The instance view of the container instance. Only valid in response.
        /// </summary>
        public ContainerPropertiesInstanceView InstanceView { get; set; }

        /// <summary>
        /// The resource requirements.
        /// </summary>
        public ResourceRequirements Resources { get; set; }

        /// <summary>
        /// The volume mounts available to the container instance.
        /// </summary>
        public VolumeMount[] VolumeMounts { get; set; }

        /// <summary>
        /// The container probe, for liveness or readiness
        /// </summary>
        public ContainerProbe LivenessProbe { get; set; }

        /// <summary>
        /// The container probe, for liveness or readiness
        /// </summary>
        public ContainerProbe ReadinessProbe { get; set; }
    }
}