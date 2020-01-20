using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.V2.Models
{
    public class KeyValueElement
    {
        public string Text { get; set; }

        public double[] BoundingBox { get; set; }

        public string[] Elements { get; set; }
    }
}
