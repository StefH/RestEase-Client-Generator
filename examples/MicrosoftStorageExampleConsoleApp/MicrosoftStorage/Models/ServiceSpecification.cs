using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// One property of operation, include metric specifications.
    /// </summary>
    public class ServiceSpecification
    {
        /// <summary>
        /// Metric specifications of operation.
        /// </summary>
        public MetricSpecification[] MetricSpecifications { get; set; }
    }
}