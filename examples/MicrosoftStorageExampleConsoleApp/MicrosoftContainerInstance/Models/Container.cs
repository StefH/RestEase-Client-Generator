using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// A container instance.
    /// </summary>
    public class Container
    {
        /// <summary>
        /// The user-provided name of the container instance.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The container instance properties.
        /// </summary>
        public ContainerProperties Properties { get; set; }
    }
}