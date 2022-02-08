using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the login flow of the custom Open ID Connect provider.
    /// </summary>
    public class OpenIdConnectLogin
    {
        /// <summary>
        /// The name of the claim that contains the users name.
        /// </summary>
        public string NameClaimType { get; set; }

        /// <summary>
        /// A list of the scopes that should be requested while authenticating.
        /// </summary>
        public string[] Scopes { get; set; }
    }
}