using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class Restriction
    {
        public string Type { get; set; }

        public string[] Values { get; set; }

        public string ReasonCode { get; set; }
    }
}