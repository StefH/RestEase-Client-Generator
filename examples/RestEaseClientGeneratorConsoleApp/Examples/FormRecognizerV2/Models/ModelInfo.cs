using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.V2.Models
{
    public class ModelInfo
    {
        public string ModelId { get; set; }

        public Status1 Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime LastUpdatedDateTime { get; set; }
    }
}
