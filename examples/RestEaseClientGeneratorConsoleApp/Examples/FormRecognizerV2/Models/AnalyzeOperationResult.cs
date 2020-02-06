using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.V2.Models
{
    public class AnalyzeOperationResult
    {
        public Status Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime LastUpdatedDateTime { get; set; }

        public AnalyzeResult AnalyzeResult { get; set; }
    }
}
