using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the app registration for providers that have client ids and client secrets
    /// </summary>
    public class ClientRegistration
    {
        /// <summary>
        /// The Client ID of the app used for login.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The app setting name that contains the client secret.
        /// </summary>
        public string ClientSecretSettingName { get; set; }
    }
}