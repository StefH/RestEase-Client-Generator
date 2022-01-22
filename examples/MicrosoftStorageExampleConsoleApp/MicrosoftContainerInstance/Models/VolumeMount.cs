using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class VolumeMount
    {
        public string Name { get; set; }

        public string MountPath { get; set; }

        public bool ReadOnly { get; set; }
    }
}