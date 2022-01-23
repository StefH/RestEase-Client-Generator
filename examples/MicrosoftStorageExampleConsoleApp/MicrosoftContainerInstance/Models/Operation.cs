using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class Operation
    {
        public string Name { get; set; }

        public Display Display { get; set; }

        public Properties Properties { get; set; }

        public string Origin { get; set; }
    }
}