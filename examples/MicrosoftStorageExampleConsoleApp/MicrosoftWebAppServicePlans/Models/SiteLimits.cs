using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Metric limits set on an app.
    /// </summary>
    public class SiteLimits
    {
        /// <summary>
        /// Maximum allowed CPU usage percentage.
        /// </summary>
        public double MaxPercentageCpu { get; set; }

        /// <summary>
        /// Maximum allowed memory usage in MB.
        /// </summary>
        public long MaxMemoryInMb { get; set; }

        /// <summary>
        /// Maximum allowed disk size usage in MB.
        /// </summary>
        public long MaxDiskSizeInMb { get; set; }
    }
}