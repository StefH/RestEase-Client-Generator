using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class VolumeMount
    {
        public string Name { get; set; }

        public string MountPath { get; set; }

        public bool ReadOnly { get; set; }
    }
}