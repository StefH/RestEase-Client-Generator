using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The container exec request.
    /// </summary>
    public class ContainerExecRequest
    {
        /// <summary>
        /// The command to be executed.
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// The container exec request.
        /// </summary>
        public ContainerExecRequestTerminalSize TerminalSize { get; set; }
    }
}