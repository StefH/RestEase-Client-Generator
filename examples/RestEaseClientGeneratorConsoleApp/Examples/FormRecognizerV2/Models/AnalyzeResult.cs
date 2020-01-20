using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.V2.Models
{
    public class AnalyzeResult
    {
        public string Version { get; set; }

        public ReadResult[] ReadResults { get; set; }

        public PageResult[] PageResults { get; set; }

        public DocumentResult[] DocumentResults { get; set; }

        public FormOperationError[] Errors { get; set; }
    }
}
