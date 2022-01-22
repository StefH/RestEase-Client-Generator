using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class MetricSpecification
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string DisplayDescription { get; set; }

        public string Unit { get; set; }

        public Dimension[] Dimensions { get; set; }

        public string AggregationType { get; set; }

        public bool FillGapWithZero { get; set; }

        public string Category { get; set; }

        public string ResourceIdDimensionNameOverride { get; set; }
    }
}