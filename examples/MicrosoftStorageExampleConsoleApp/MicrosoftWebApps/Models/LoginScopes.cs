using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the login flow, including the scopes that should be requested.
    /// </summary>
    public class LoginScopes
    {
        /// <summary>
        /// A list of the scopes that should be requested while authenticating.
        /// </summary>
        public string[] Scopes { get; set; }
    }
}