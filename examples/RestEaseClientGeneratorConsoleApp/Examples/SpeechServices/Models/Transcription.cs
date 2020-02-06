using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models
{
    public class Transcription
    {
        public string RecordingsUrl { get; set; }

        public string ReportFileUrl { get; set; }

        public string Id { get; set; }

        public Model[] Models { get; set; }

        public string Locale { get; set; }

        public object ResultsUrls { get; set; }

        public string StatusMessage { get; set; }

        public DateTime LastActionDateTime { get; set; }

        public Status Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public object Properties { get; set; }
    }
}
