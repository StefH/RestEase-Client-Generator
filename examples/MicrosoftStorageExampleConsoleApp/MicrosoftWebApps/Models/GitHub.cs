using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the GitHub provider.
    /// </summary>
    public class GitHub
    {
        /// <summary>
        /// false if the GitHub provider should not be enabled despite the set registration; otherwise, true.
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
    }
}