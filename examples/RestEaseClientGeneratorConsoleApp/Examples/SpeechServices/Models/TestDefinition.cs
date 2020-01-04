using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.SpeechServices.Models
{
    public class TestDefinition
    {
        public ModelIdentity[] Models { get; set; }

        public DatasetIdentity Dataset { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public object Properties { get; set; }
    }
}
