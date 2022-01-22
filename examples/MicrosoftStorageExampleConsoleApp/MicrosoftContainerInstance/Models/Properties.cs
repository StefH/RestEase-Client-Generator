using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class Properties
    {
        public string ProvisioningState { get; set; }

        public Container[] Containers { get; set; }

        public ImageRegistryCredential[] ImageRegistryCredentials { get; set; }

        public string RestartPolicy { get; set; }

        public string OsType { get; set; }

        public Volume[] Volumes { get; set; }

        public Event[] Events { get; set; }

        public string State { get; set; }

        public ContainerGroupSubnetId[] SubnetIds { get; set; }

        public string Sku { get; set; }

        public InitContainerDefinition[] InitContainers { get; set; }
    }
}