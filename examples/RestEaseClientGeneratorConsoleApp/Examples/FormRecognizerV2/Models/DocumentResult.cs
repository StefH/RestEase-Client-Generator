using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.V2.Models
{
    public class DocumentResult
    {
        public string DocType { get; set; }

        public int[] PageRange { get; set; }

        public Dictionary<string, FieldValue> Fields { get; set; }
    }
}
