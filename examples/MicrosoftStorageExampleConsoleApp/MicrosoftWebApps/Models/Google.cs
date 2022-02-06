using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the Google provider.
    /// </summary>
    public class Google
    {
        /// <summary>
        /// false if the Google provider should not be enabled despite the set registration; otherwise, true.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The configuration settings of the app registration for providers that have client ids and client secrets
        /// </summary>
        public ClientRegistration Registration { get; set; }

        /// <summary>
        /// The configuration settings of the login flow, including the scopes that should be requested.
        /// </summary>
        public LoginScopes Login { get; set; }

        /// <summary>
        /// The configuration settings of the Allowed Audiences validation flow.
        /// </summary>
        public AllowedAudiencesValidation Validation { get; set; }
    }
}