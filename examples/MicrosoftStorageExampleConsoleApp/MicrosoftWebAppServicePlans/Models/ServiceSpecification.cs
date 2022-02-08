using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Resource metrics service provided by Microsoft.Insights resource provider.
    /// </summary>
    public class ServiceSpecification
    {
        public MetricSpecification[] MetricSpecifications { get; set; }

        public LogSpecification[] LogSpecifications { get; set; }
    }
}