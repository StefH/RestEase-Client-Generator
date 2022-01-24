using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The container execution command, for liveness or readiness probe
    /// </summary>
    public class ContainerExec
    {
        /// <summary>
        /// The commands to execute within the container.
        /// </summary>
        public string[] Command { get; set; }
    }
}