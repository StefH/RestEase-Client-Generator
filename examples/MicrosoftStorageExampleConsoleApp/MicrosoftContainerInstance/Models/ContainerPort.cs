using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The port exposed on the container instance.
    /// </summary>
    public class ContainerPort
    {
        /// <summary>
        /// The protocol associated with the port.
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// The port number exposed within the container group.
        /// </summary>
        public int Port { get; set; }
    }
}