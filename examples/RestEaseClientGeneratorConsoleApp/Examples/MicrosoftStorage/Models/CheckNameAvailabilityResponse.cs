using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class CheckNameAvailabilityResponse
    {
        public bool NameAvailable { get; set; }

        public string Reason { get; set; }

        public string Message { get; set; }
    }
}