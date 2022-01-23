using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class ContainerExecRequest
    {
        public string Command { get; set; }

        public TerminalSize TerminalSize { get; set; }
    }
}