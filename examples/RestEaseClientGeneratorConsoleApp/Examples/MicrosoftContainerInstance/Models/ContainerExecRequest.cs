using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
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
        public TerminalSize TerminalSize { get; set; }
    }
}