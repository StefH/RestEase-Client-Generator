using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Usage of the quota resource.
    /// </summary>
    public class CsmUsageQuota
    {
        /// <summary>
        /// Units of measurement for the quota resource.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Next reset time for the resource counter.
        /// </summary>
        public DateTime NextResetTime { get; set; }

        /// <summary>
        /// The current value of the resource counter.
        /// </summary>
        public long CurrentValue { get; set; }

        /// <summary>
        /// The resource limit.
        /// </summary>
        public long Limit { get; set; }

        /// <summary>
        /// Localizable string object containing the name and a localized value.
        /// </summary>
        public LocalizableString Name { get; set; }
    }
}