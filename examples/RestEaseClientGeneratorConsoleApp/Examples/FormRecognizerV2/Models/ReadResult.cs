using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.V2.Models
{
    public class ReadResult
    {
        public int Page { get; set; }

        public double Angle { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public string Unit { get; set; }

        public string Language { get; set; }

        public TextLine[] Lines { get; set; }
    }
}
