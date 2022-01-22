using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class ContainerExecRequest
    {
        public string Command { get; set; }

        public int Rows { get; set; }

        public int Cols { get; set; }
    }
}