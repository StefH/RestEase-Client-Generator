using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    public class Usage
    {
        public string Unit { get; set; }

        public int CurrentValue { get; set; }

        public int Limit { get; set; }

        public UsageName Name { get; set; }
    }
}