using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.SpeechServices.Models
{
    public class ModelTrainingLocales
    {
        public string[] None { get; set; }

        public string[] Acoustic { get; set; }

        public string[] Language { get; set; }

        public string[] AcousticAndLanguage { get; set; }

        public string[] CustomVoice { get; set; }

        public string[] Sentiment { get; set; }

        public string[] LanguageIdentification { get; set; }

        public string[] Diarization { get; set; }

        public string[] Keyword { get; set; }
    }
}
