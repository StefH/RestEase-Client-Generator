using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class InstanceView
    {
        public Event[] Events { get; set; }

        public string State { get; set; }
    }
}