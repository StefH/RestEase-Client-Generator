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
        /// not-used
        /// </summary>
        public ContainerGroupIdentity Identity { get; set; }

        public Properties Properties { get; set; }
    }
}