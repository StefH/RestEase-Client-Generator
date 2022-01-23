using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class ContainerGroup : Resource
    {
        public ContainerGroupIdentity Identity { get; set; }

        public Properties Properties { get; set; }
    }
}