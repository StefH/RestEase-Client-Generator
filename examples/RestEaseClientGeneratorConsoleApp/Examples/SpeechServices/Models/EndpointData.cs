using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models
{
    public class EndpointData
    {
        public string Id { get; set; }

        public string DataUrl { get; set; }

        public DateTime LastActionDateTime { get; set; }

        public Status Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
