using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class Operation
    {
        public string Name { get; set; }

        public object Display { get; set; }

        public string Origin { get; set; }

        public OperationProperties Properties { get; set; }
    }
}