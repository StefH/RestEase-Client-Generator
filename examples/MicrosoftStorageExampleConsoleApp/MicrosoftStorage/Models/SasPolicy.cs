using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class SasPolicy
    {
        public string SasExpirationPeriod { get; set; }

        public string ExpirationAction { get; set; }
    }
}