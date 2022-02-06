using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Cross-Origin Resource Sharing (CORS) settings for the app.
    /// </summary>
    public class CorsSettings
    {
        /// <summary>
        /// Gets or sets the list of origins that should be allowed to make cross-origincalls (for example: http://example.com:12345). Use "*" to allow all.
        /// </summary>
        public string[] AllowedOrigins { get; set; }

        /// <summary>
        /// Gets or sets whether CORS requests with credentials are allowed. See https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentialsfor more details.
        /// </summary>
        public bool SupportCredentials { get; set; }
    }
}