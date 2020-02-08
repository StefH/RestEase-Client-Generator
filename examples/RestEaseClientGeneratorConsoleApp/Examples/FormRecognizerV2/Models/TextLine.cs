using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.V2.Models
{
    public class TextLine
    {
        public string Text { get; set; }

        public double[] BoundingBox { get; set; }

        public string Language { get; set; }

        public TextWord[] Words { get; set; }
    }
}
