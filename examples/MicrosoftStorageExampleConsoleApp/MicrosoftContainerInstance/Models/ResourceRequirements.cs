using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class ResourceRequirements
    {
        public ResourceRequests Requests { get; set; }

        public ResourceLimits Limits { get; set; }
    }
}