using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the platform of App Service Authentication/Authorization.
    /// </summary>
    public class AuthPlatform
    {
        /// <summary>
        /// true if the Authentication / Authorization feature is enabled for the current app; otherwise, false.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The RuntimeVersion of the Authentication / Authorization feature in use for the current app.The setting in this value can control the behavior of certain features in the Authentication / Authorization module.
        /// </summary>
        public string RuntimeVersion { get; set; }

        /// <summary>
        /// The path of the config file containing auth settings if they come from a file.If the path is relative, base will the site's root directory.
        /// </summary>
        public string ConfigFilePath { get; set; }
    }
}