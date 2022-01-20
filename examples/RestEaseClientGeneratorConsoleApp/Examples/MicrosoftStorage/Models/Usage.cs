using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class Usage
    {
        public string Unit { get; set; }

        public int CurrentValue { get; set; }

        public int Limit { get; set; }

        public UsageName Name { get; set; }
    }
}