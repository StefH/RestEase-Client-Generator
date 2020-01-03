using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.Models
{
    public class Models
    {
        public object Summary { get; set; }

        public ModelInfo[] ModelList { get; set; }

        public string NextLink { get; set; }
    }
}
