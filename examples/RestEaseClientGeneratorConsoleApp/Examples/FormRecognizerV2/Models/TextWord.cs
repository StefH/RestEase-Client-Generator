using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.V2.Models
{
    public class TextWord
    {
        public string Text { get; set; }

        public double[] BoundingBox { get; set; }

        public double Confidence { get; set; }
    }
}
