using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Log Definition of a single resource metric.
    /// </summary>
    public class LogSpecification
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string BlobDuration { get; set; }

        public string LogFilterPattern { get; set; }
    }
}