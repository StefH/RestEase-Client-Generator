using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Resource metrics service provided by Microsoft.Insights resource provider.
    /// </summary>
    public class ServiceSpecification
    {
        /// <summary>
        /// Definition of a single resource metric.
        /// </summary>
        public MetricSpecification[] MetricSpecifications { get; set; }

        /// <summary>
        /// Log Definition of a single resource metric.
        /// </summary>
        public LogSpecification[] LogSpecifications { get; set; }
    }
}