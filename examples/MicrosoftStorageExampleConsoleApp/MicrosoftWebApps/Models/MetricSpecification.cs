using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Definition of a single resource metric.
    /// </summary>
    public class MetricSpecification
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string DisplayDescription { get; set; }

        public string Unit { get; set; }

        public string AggregationType { get; set; }

        public bool SupportsInstanceLevelAggregation { get; set; }

        public bool EnableRegionalMdmAccount { get; set; }

        public string SourceMdmAccount { get; set; }

        public string SourceMdmNamespace { get; set; }

        public string MetricFilterPattern { get; set; }

        public bool FillGapWithZero { get; set; }

        public bool IsInternal { get; set; }

        public Dimension[] Dimensions { get; set; }

        public string Category { get; set; }

        public MetricAvailability[] Availabilities { get; set; }

        public string[] SupportedTimeGrainTypes { get; set; }

        public string[] SupportedAggregationTypes { get; set; }
    }
}