using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    public class Operation
    {
        public string Name { get; set; }

        public string Origin { get; set; }

        public OperationProperties Properties { get; set; }
    }
}