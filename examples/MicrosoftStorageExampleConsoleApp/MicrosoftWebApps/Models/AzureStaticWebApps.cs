using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the Azure Static Web Apps provider.
    /// </summary>
    public class AzureStaticWebApps
    {
        /// <summary>
        /// false if the Azure Static Web Apps provider should not be enabled despite the set registration; otherwise, true.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The configuration settings of the registration for the Azure Static Web Apps provider
        /// </summary>
        public AzureStaticWebAppsRegistration Registration { get; set; }
    }
}