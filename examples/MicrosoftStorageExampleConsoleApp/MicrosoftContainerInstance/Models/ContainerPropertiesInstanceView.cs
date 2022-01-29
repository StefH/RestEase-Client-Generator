using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The instance view of the container instance. Only valid in response.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class ContainerPropertiesInstanceView
    {
        /// <summary>
        /// The number of times that the container instance has been restarted.
        /// </summary>
        public int RestartCount { get; set; }

        /// <summary>
        /// The container instance state.
        /// </summary>
        public ContainerState CurrentState { get; set; }

        /// <summary>
        /// The container instance state.
        /// </summary>
        public ContainerState PreviousState { get; set; }

        /// <summary>
        /// The events of the container instance.
        /// </summary>
        public Event[] Events { get; set; }
    }
}