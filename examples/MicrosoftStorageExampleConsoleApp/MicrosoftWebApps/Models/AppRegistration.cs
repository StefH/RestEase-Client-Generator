using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the app registration for providers that have app ids and app secrets
    /// </summary>
    public class AppRegistration
    {
        /// <summary>
        /// The App ID of the app used for login.
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// The app setting name that contains the app secret.
        /// </summary>
        public string AppSecretSettingName { get; set; }
    }
}