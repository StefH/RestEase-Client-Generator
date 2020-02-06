using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models
{
    public class HealthStatusResponse
    {
        public Status1 Status { get; set; }

        public string Message { get; set; }

        public Component[] Components { get; set; }
    }
}
