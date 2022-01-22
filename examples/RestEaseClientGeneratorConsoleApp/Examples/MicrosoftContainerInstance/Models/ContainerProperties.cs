using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class ContainerProperties
    {
        public string Image { get; set; }

        public string[] Command { get; set; }

        public ContainerPort[] Ports { get; set; }

        public EnvironmentVariable[] EnvironmentVariables { get; set; }

        public ResourceRequirements Resources { get; set; }

        public VolumeMount[] VolumeMounts { get; set; }

        public ContainerProbe LivenessProbe { get; set; }

        public ContainerProbe ReadinessProbe { get; set; }
    }
}