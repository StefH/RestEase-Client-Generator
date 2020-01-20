using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.V2.Models
{
    public class PageResult
    {
        public int Page { get; set; }

        public int ClusterId { get; set; }

        public KeyValuePair[] KeyValuePairs { get; set; }

        public DataTable[] Tables { get; set; }
    }
}
