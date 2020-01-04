using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.Models
{
    public class AnalyzeResult
    {
        public string Version { get; set; }

        public ReadResult[] ReadResults { get; set; }

        public PageResult[] PageResults { get; set; }

        public object[] DocumentResults { get; set; }

        public FormOperationError[] Errors { get; set; }
    }
}
