using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the Apple provider.
    /// </summary>
    public class Apple
    {
        /// <summary>
        /// false if the Apple provider should not be enabled despite the set registration; otherwise, true.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The configuration settings of the registration for the Apple provider
        /// </summary>
        public AppleRegistration Registration { get; set; }

        /// <summary>
        /// The configuration settings of the login flow, including the scopes that should be requested.
        /// </summary>
        public LoginScopes Login { get; set; }
    }
}