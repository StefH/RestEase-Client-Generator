using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.Models
{
    public class TrainResult
    {
        public TrainingDocumentInfo[] TrainingDocuments { get; set; }

        public FormFieldsReport[] Fields { get; set; }

        public double AverageModelAccuracy { get; set; }

        public FormOperationError[] Errors { get; set; }
    }
}
