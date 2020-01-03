using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.Models
{
    public class KeyValuePair
    {
        public string Label { get; set; }

        public KeyValueElement Key { get; set; }

        public KeyValueElement Value { get; set; }

        public double Confidence { get; set; }
    }
}
