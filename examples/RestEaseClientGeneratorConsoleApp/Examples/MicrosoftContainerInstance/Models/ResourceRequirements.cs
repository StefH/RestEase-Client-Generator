using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class ResourceRequirements
    {
        public ResourceRequests Requests { get; set; }

        public ResourceLimits Limits { get; set; }
    }
}