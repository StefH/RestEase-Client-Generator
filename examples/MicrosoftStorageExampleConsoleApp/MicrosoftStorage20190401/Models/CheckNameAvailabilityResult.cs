using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    public class CheckNameAvailabilityResult
    {
        public bool NameAvailable { get; set; }

        public string Reason { get; set; }

        public string Message { get; set; }
    }
}