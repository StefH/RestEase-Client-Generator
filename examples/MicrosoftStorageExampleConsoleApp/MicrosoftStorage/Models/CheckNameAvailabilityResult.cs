using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class CheckNameAvailabilityResult
    {
        public bool NameAvailable { get; set; }

        public string Reason { get; set; }

        public string Message { get; set; }
    }
}