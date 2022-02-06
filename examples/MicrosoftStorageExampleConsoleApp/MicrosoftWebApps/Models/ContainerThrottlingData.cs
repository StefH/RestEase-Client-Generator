using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    public class ContainerThrottlingData
    {
        public int Periods { get; set; }

        public int ThrottledPeriods { get; set; }

        public int ThrottledTime { get; set; }
    }
}