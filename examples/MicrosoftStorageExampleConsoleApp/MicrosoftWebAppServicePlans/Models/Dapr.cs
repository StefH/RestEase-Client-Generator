using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Container App Dapr configuration.
    /// </summary>
    public class Dapr
    {
        /// <summary>
        /// Boolean indicating if the Dapr side car is enabled
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Dapr application identifier
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// Port on which the Dapr side car
        /// </summary>
        public int AppPort { get; set; }

        /// <summary>
        /// Collection of Dapr components
        /// </summary>
        public DaprComponent[] Components { get; set; }
    }
}