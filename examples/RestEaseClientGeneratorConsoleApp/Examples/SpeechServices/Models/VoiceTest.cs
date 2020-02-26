using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models
{
    public class VoiceTest
    {
        public string Id { get; set; }

        public string AudioUri { get; set; }

        public string TextUri { get; set; }

        public DateTime LastActionDateTime { get; set; }

        public Status Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public Model Model { get; set; }

        public VoiceTestKind VoiceTestKind { get; set; }
    }
}
