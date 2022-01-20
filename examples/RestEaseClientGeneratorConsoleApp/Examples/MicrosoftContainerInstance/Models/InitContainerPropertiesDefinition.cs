using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class InitContainerPropertiesDefinition
    {
        public string Image { get; set; }

        public string[] Command { get; set; }

        public EnvironmentVariable[] EnvironmentVariables { get; set; }

        public object InstanceView { get; set; }

        public VolumeMount[] VolumeMounts { get; set; }
    }
}