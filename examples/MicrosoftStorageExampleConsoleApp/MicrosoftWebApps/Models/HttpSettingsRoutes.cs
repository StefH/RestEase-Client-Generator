using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the paths HTTP requests.
    /// </summary>
    public class HttpSettingsRoutes
    {
        /// <summary>
        /// The prefix that should precede all the authentication/authorization paths.
        /// </summary>
        public string ApiPrefix { get; set; }
    }
}