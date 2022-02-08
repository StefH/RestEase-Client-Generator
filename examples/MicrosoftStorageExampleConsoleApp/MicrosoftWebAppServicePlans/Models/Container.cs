using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Container App container definition.
    /// </summary>
    public class Container
    {
        /// <summary>
        /// Container image tag.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Custom container name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Container start command.
        /// </summary>
        public string[] Command { get; set; }

        /// <summary>
        /// Container start command arguments.
        /// </summary>
        public string[] Args { get; set; }

        /// <summary>
        /// Container environment variables.
        /// </summary>
        public EnvironmentVar[] Env { get; set; }

        /// <summary>
        /// Container App container resource requirements.
        /// </summary>
        public ContainerResources Resources { get; set; }
    }
}