using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class OperationStatusResult
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public double PercentComplete { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public OperationStatusResult[] Operations { get; set; }

        public ErrorDetail Error { get; set; }
    }
}