using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class ContainerExecRequest
    {
        public string Command { get; set; }

        public object TerminalSize { get; set; }
    }
}