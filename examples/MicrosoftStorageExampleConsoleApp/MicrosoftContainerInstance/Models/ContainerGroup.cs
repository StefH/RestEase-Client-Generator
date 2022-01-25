using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// A container group.
    /// </summary>
    public class ContainerGroup : Resource
    {
        /// <summary>
        /// Identity for the container group.
        /// </summary>
        public ContainerGroupIdentity Identity { get; set; }

        /// <summary>
        /// The container group properties
        /// </summary>
        public ContainerGroupProperties Properties { get; set; }
    }
}