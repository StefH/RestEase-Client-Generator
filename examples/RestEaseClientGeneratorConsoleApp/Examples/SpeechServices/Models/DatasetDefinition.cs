using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models
{
    public class DatasetDefinition
    {
        public string DataImportKind { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public object Properties { get; set; }

        public string Locale { get; set; }
    }
}
