using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The container exec request.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class ContainerExecRequest
    {
        /// <summary>
        /// The command to be executed.
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// The size of the terminal.
        /// </summary>
        public ContainerExecRequestTerminalSize TerminalSize { get; set; }
    }
}