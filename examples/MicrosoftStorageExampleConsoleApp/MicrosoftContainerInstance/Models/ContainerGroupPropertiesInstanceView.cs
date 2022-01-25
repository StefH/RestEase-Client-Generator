using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The instance view of the container group. Only valid in response.
    /// </summary>
    public class ContainerGroupPropertiesInstanceView
    {
        /// <summary>
        /// The events of this container group.
        /// </summary>
        public Event[] Events { get; set; }

        /// <summary>
        /// The state of the container group. Only valid in response.
        /// </summary>
        public string State { get; set; }
    }
}