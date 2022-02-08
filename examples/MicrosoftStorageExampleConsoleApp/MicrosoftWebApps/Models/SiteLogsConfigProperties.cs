using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// SiteLogsConfig resource specific properties
    /// </summary>
    public class SiteLogsConfigProperties
    {
        /// <summary>
        /// Application logs configuration.
        /// </summary>
        public ApplicationLogsConfig ApplicationLogs { get; set; }

        /// <summary>
        /// Http logs configuration.
        /// </summary>
        public HttpLogsConfig HttpLogs { get; set; }

        /// <summary>
        /// Enabled configuration.
        /// </summary>
        public EnabledConfig FailedRequestsTracing { get; set; }

        /// <summary>
        /// Enabled configuration.
        /// </summary>
        public EnabledConfig DetailedErrorMessages { get; set; }
    }
}