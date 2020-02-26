using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models
{
    public class Test
    {
        public string ResultsUrl { get; set; }

        public string Id { get; set; }

        public double WordErrorRate { get; set; }

        public DateTime LastActionDateTime { get; set; }

        public Status Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public Model[] Models { get; set; }

        public Dataset Dataset { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public object Properties { get; set; }
    }
}
