using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The instance view of the init container. Only valid in response.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class InitContainerPropertiesDefinitionInstanceView
    {
        /// <summary>
        /// The number of times that the init container has been restarted.
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
        /// The events of the init container.
        /// </summary>
        public Event[] Events { get; set; }
    }
}