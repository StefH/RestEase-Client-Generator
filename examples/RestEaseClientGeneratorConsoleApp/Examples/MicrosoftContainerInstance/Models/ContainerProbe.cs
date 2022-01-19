using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class ContainerProbe
    {
        public ContainerExec Exec { get; set; }

        public ContainerHttpGet HttpGet { get; set; }

        public int InitialDelaySeconds { get; set; }

        public int PeriodSeconds { get; set; }

        public int FailureThreshold { get; set; }

        public int SuccessThreshold { get; set; }

        public int TimeoutSeconds { get; set; }
    }
}
