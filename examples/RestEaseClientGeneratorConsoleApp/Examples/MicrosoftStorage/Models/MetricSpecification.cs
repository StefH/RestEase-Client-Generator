using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Metric specification of operation.
    /// </summary>
    public class MetricSpecification
    {
        /// <summary>
        /// Name of metric specification.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Display name of metric specification.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Display description of metric specification.
        /// </summary>
        public string DisplayDescription { get; set; }

        /// <summary>
        /// Unit could be Bytes or Count.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Dimensions of blobs, including blob type and access tier.
        /// </summary>
        public Dimension[] Dimensions { get; set; }

        /// <summary>
        /// Aggregation type could be Average.
        /// </summary>
        public string AggregationType { get; set; }

        /// <summary>
        /// The property to decide fill gap with zero or not.
        /// </summary>
        public bool FillGapWithZero { get; set; }

        /// <summary>
        /// The category this metric specification belong to, could be Capacity.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Account Resource Id.
        /// </summary>
        public string ResourceIdDimensionNameOverride { get; set; }
    }
}