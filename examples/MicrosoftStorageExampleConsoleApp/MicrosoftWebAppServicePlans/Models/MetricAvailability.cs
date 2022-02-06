using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Retention policy of a resource metric.
    /// </summary>
    public class MetricAvailability
    {
        public string TimeGrain { get; set; }

        public string BlobDuration { get; set; }
    }
}