using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Additional configuration for a data providers
    /// </summary>
    public class DataProviderMetadata
    {
        public string ProviderName { get; set; }

        /// <summary>
        /// Settings for the data provider
        /// </summary>
        public KeyValuePairStringObject[] PropertyBag { get; set; }
    }
}