using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the app registration for the custom Open ID Connect provider.
    /// </summary>
    public class OpenIdConnectRegistration
    {
        /// <summary>
        /// The client id of the custom Open ID Connect provider.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The authentication client credentials of the custom Open ID Connect provider.
        /// </summary>
        public OpenIdConnectClientCredential ClientCredential { get; set; }

        /// <summary>
        /// The configuration settings of the endpoints used for the custom Open ID Connect provider.
        /// </summary>
        public OpenIdConnectConfig OpenIdConnectConfiguration { get; set; }
    }
}