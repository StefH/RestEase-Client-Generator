using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class Volume
    {
        public string Name { get; set; }

        public AzureFileVolume AzureFile { get; set; }

        public EmptyDirVolume EmptyDir { get; set; }

        public SecretVolume Secret { get; set; }

        public GitRepoVolume GitRepo { get; set; }
    }
}