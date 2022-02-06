using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Definition of Detector
    /// </summary>
    public class DetectorInfo
    {
        /// <summary>
        /// Id of detector
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of detector
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short description of the detector and its purpose.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Author of the detector.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Problem category. This serves for organizing group for detectors.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// List of Support Topics for which this detector is enabled.
        /// </summary>
        public SupportTopic[] SupportTopicList { get; set; }

        /// <summary>
        /// Analysis Types for which this detector should apply to.
        /// </summary>
        public string[] AnalysisType { get; set; }

        /// <summary>
        /// Whether this detector is an Analysis Detector or not.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Defines score of a detector to power ML based matching.
        /// </summary>
        public float Score { get; set; }
    }
}