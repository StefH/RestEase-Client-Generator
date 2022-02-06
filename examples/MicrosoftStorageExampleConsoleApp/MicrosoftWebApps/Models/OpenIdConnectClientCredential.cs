using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The authentication client credentials of the custom Open ID Connect provider.
    /// </summary>
    public class OpenIdConnectClientCredential
    {
        /// <summary>
        /// The method that should be used to authenticate the user.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// The app setting that contains the client secret for the custom Open ID Connect provider.
        /// </summary>
        public string ClientSecretSettingName { get; set; }
    }
}