using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the HTTP requests for authentication and authorization requests made against App Service Authentication/Authorization.
    /// </summary>
    public class HttpSettings
    {
        /// <summary>
        /// false if the authentication/authorization responses not having the HTTPS scheme are permissible; otherwise, true.
        /// </summary>
        public bool RequireHttps { get; set; }

        /// <summary>
        /// The configuration settings of the paths HTTP requests.
        /// </summary>
        public HttpSettingsRoutes Routes { get; set; }

        /// <summary>
        /// The configuration settings of a forward proxy used to make the requests.
        /// </summary>
        public ForwardProxy ForwardProxy { get; set; }
    }
}