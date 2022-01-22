using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class ContainerState
    {
        public string State { get; set; }

        public DateTime StartTime { get; set; }

        public int ExitCode { get; set; }

        public DateTime FinishTime { get; set; }

        public string DetailStatus { get; set; }
    }
}