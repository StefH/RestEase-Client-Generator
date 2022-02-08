using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the registration for the Azure Static Web Apps provider
    /// </summary>
    public class AzureStaticWebAppsRegistration
    {
        /// <summary>
        /// The Client ID of the app used for login.
        /// </summary>
        public string ClientId { get; set; }
    }
}