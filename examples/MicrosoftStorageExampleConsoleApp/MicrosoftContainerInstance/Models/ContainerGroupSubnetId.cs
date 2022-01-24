using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// Container group subnet information.
    /// </summary>
    public class ContainerGroupSubnetId
    {
        /// <summary>
        /// Resource ID of virtual network and subnet.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Friendly name for the subnet.
        /// </summary>
        public string Name { get; set; }
    }
}