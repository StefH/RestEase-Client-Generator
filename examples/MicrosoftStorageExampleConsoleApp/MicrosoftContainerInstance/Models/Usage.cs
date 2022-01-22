using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class Usage
    {
        public string Unit { get; set; }

        public int CurrentValue { get; set; }

        public int Limit { get; set; }

        public string Value { get; set; }

        public string LocalizedValue { get; set; }
    }
}