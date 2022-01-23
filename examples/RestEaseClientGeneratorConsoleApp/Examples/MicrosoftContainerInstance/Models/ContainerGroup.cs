using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class ContainerGroup : Resource
    {
        public ContainerGroupIdentity Identity { get; set; }

        public Properties Properties { get; set; }
    }
}