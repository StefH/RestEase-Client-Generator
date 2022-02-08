using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the Facebook provider.
    /// </summary>
    public class Facebook
    {
        /// <summary>
        /// false if the Facebook provider should not be enabled despite the set registration; otherwise, true.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The configuration settings of the app registration for providers that have app ids and app secrets
        /// </summary>
        public AppRegistration Registration { get; set; }

        /// <summary>
        /// The version of the Facebook api to be used while logging in.
        /// </summary>
        public string GraphApiVersion { get; set; }

        /// <summary>
        /// The configuration settings of the login flow, including the scopes that should be requested.
        /// </summary>
        public LoginScopes Login { get; set; }
    }
}