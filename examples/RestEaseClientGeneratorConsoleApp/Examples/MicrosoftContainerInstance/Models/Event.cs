using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class Event
    {
        public int Count { get; set; }

        public DateTime FirstTimestamp { get; set; }

        public DateTime LastTimestamp { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public string Type { get; set; }
    }
}