using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class EnvironmentVariable
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string SecureValue { get; set; }
    }
}