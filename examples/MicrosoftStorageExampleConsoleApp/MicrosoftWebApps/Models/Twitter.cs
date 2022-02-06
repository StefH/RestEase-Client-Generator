using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the Twitter provider.
    /// </summary>
    public class Twitter
    {
        /// <summary>
        /// false if the Twitter provider should not be enabled despite the set registration; otherwise, true.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The configuration settings of the app registration for the Twitter provider.
        /// </summary>
        public TwitterRegistration Registration { get; set; }
    }
}