using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models
{
    public class Dataset
    {
        public string Id { get; set; }

        public DataImportKind DataImportKind { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public object Properties { get; set; }

        public string Locale { get; set; }

        public DateTime LastActionDateTime { get; set; }

        public Status Status { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
