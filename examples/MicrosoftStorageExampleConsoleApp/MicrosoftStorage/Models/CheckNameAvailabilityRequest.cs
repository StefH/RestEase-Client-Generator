using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class CheckNameAvailabilityRequest
    {
        public string Name { get; set; }

        public string Type { get; set; }
    }
}