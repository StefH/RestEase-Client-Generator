using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the Azure Active Directory login flow.
    /// </summary>
    public class AzureActiveDirectoryLogin
    {
        /// <summary>
        /// Login parameters to send to the OpenID Connect authorization endpoint whena user logs in. Each parameter must be in the form "key=value".
        /// </summary>
        public string[] LoginParameters { get; set; }

        /// <summary>
        /// true if the www-authenticate provider should be omitted from the request; otherwise, false.
        /// </summary>
        public bool DisableWWWAuthenticate { get; set; }
    }
}