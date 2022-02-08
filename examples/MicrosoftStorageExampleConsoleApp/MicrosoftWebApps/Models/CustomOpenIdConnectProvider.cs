using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the custom Open ID Connect provider.
    /// </summary>
    public class CustomOpenIdConnectProvider
    {
        /// <summary>
        /// false if the custom Open ID provider provider should not be enabled; otherwise, true.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The configuration settings of the app registration for the custom Open ID Connect provider.
        /// </summary>
        public OpenIdConnectRegistration Registration { get; set; }

        /// <summary>
        /// The configuration settings of the login flow of the custom Open ID Connect provider.
        /// </summary>
        public OpenIdConnectLogin Login { get; set; }
    }
}