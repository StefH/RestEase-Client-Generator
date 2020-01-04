using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.Models
{
    public class TrainingDocumentInfo
    {
        public string DocumentName { get; set; }

        public int Pages { get; set; }

        public string[] Errors { get; set; }

        public string Status { get; set; }
    }
}
