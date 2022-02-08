using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Description of the App Service plan scale options.
    /// </summary>
    public class SkuCapacity
    {
        /// <summary>
        /// Minimum number of workers for this App Service plan SKU.
        /// </summary>
        public int Minimum { get; set; }

        /// <summary>
        /// Maximum number of workers for this App Service plan SKU.
        /// </summary>
        public int Maximum { get; set; }

        /// <summary>
        /// Maximum number of Elastic workers for this App Service plan SKU.
        /// </summary>
        public int ElasticMaximum { get; set; }

        /// <summary>
        /// Default number of workers for this App Service plan SKU.
        /// </summary>
        public int Default { get; set; }

        /// <summary>
        /// Available scale configurations for an App Service plan.
        /// </summary>
        public string ScaleType { get; set; }
    }
}