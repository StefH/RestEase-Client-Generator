using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class InstanceView
    {
        public Event[] Events { get; set; }

        public string State { get; set; }
    }
}