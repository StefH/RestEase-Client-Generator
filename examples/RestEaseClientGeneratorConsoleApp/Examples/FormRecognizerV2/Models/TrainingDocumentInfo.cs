using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.V2.Models
{
    public class TrainingDocumentInfo
    {
        public string DocumentName { get; set; }

        public int Pages { get; set; }

        public string[] Errors { get; set; }

        public Status2 Status { get; set; }
    }
}
