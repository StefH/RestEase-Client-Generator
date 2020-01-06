using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models
{
    public class TranscriptionDefinition
    {
        public string RecordingsUrl { get; set; }

        public ModelIdentity[] Models { get; set; }

        public string Locale { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public object Properties { get; set; }
    }
}
