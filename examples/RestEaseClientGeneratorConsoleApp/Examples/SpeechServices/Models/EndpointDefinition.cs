using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models
{
    public class EndpointDefinition
    {
        public int ConcurrentRecognitions { get; set; }

        public ModelIdentity[] Models { get; set; }

        public bool ContentLoggingEnabled { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public object Properties { get; set; }

        public string Locale { get; set; }
    }
}
