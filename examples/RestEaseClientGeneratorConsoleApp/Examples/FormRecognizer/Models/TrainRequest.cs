using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.Models
{
    public class TrainRequest
    {
        public string Source { get; set; }

        public TrainSourceFilter SourceFilter { get; set; }

        public bool UseLabelFile { get; set; }
    }
}
