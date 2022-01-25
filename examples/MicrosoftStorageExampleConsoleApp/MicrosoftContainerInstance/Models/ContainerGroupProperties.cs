using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The container group properties
    /// </summary>
    public class ContainerGroupProperties
    {
        /// <summary>
        /// The provisioning state of the container group. This only appears in the response.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// The containers within the container group.
        /// </summary>
        public Container[] Containers { get; set; }

        /// <summary>
        /// The image registry credentials by which the container group is created from.
        /// </summary>
        public ImageRegistryCredential[] ImageRegistryCredentials { get; set; }

        /// <summary>
        /// Restart policy for all containers within the container group. - `Always` Always restart- `OnFailure` Restart on failure- `Never` Never restart
        /// </summary>
        public string RestartPolicy { get; set; }

        /// <summary>
        /// IP address for the container group.
        /// </summary>
        public IpAddress IpAddress { get; set; }

        /// <summary>
        /// The operating system type required by the containers in the container group.
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        /// The list of volumes that can be mounted by containers in this container group.
        /// </summary>
        public Volume[] Volumes { get; set; }

        /// <summary>
        /// The instance view of the container group. Only valid in response.
        /// </summary>
        public ContainerGroupPropertiesInstanceView InstanceView { get; set; }

        /// <summary>
        /// Container group diagnostic information.
        /// </summary>
        public ContainerGroupDiagnostics Diagnostics { get; set; }

        /// <summary>
        /// The subnet resource IDs for a container group.
        /// </summary>
        public ContainerGroupSubnetId[] SubnetIds { get; set; }

        /// <summary>
        /// DNS configuration for the container group.
        /// </summary>
        public DnsConfiguration DnsConfig { get; set; }

        /// <summary>
        /// The container group SKU.
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// The container group encryption properties.
        /// </summary>
        public EncryptionProperties EncryptionProperties { get; set; }

        /// <summary>
        /// The init containers for a container group.
        /// </summary>
        public InitContainerDefinition[] InitContainers { get; set; }
    }
}