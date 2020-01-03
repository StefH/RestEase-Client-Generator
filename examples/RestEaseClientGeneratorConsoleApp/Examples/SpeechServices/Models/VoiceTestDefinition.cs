using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models
{
    public class VoiceTestDefinition
    {
        public string Text { get; set; }

        public ModelIdentity Model { get; set; }

        public string VoiceTestKind { get; set; }
    }
}
