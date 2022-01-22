using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class ContainerProperties
    {
        public string Image { get; set; }

        public string[] Command { get; set; }

        public ContainerPort[] Ports { get; set; }

        public EnvironmentVariable[] EnvironmentVariables { get; set; }

        public Event[] Events { get; set; }

        public string State { get; set; }

        public VolumeMount[] VolumeMounts { get; set; }
    }
}