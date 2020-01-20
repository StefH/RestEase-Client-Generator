using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.V2.Models
{
    public class Model
    {
        public ModelInfo ModelInfo { get; set; }

        public KeysResult Keys { get; set; }

        public TrainResult TrainResult { get; set; }
    }
}
