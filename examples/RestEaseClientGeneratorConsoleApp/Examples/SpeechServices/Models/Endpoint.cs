using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models
{
    public class Endpoint
    {
        public int ConcurrentRecognitions { get; set; }

        public string Id { get; set; }

        public object EndpointUrls { get; set; }

        public EndpointKind EndpointKind { get; set; }

        public DateTime LastActionDateTime { get; set; }

        public Status Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public Model[] Models { get; set; }

        public bool ContentLoggingEnabled { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public object Properties { get; set; }

        public string Locale { get; set; }
    }
}
