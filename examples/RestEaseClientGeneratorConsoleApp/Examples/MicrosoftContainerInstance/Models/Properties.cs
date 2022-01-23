using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class Properties
    {
        public string ProvisioningState { get; set; }

        public Container[] Containers { get; set; }

        public ImageRegistryCredential[] ImageRegistryCredentials { get; set; }

        public string RestartPolicy { get; set; }

        public IpAddress IpAddress { get; set; }

        public string OsType { get; set; }

        public Volume[] Volumes { get; set; }

        public InstanceView InstanceView { get; set; }

        public ContainerGroupDiagnostics Diagnostics { get; set; }

        public ContainerGroupSubnetId[] SubnetIds { get; set; }

        public DnsConfiguration DnsConfig { get; set; }

        public string Sku { get; set; }

        public EncryptionProperties EncryptionProperties { get; set; }

        public InitContainerDefinition[] InitContainers { get; set; }
    }
}