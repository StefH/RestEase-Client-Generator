using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class DateAfterModification
    {
        public double DaysAfterModificationGreaterThan { get; set; }

        public double DaysAfterLastAccessTimeGreaterThan { get; set; }
    }
}