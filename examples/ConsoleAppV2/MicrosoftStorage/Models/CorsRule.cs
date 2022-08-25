using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Specifies a CORS rule for the Blob service.
    /// </summary>
    public class CorsRule
    {
        /// <summary>
        /// Required if CorsRule element is present. A list of origin domains that will be allowed via CORS, or "*" to allow all domains
        /// </summary>
        public string[] AllowedOrigins { get; set; }

        /// <summary>
        /// Required if CorsRule element is present. A list of HTTP methods that are allowed to be executed by the origin.
        /// </summary>
        public string[] AllowedMethods { get; set; }

        /// <summary>
        /// Required if CorsRule element is present. The number of seconds that the client/browser should cache a preflight response.
        /// </summary>
        public int MaxAgeInSeconds { get; set; }

        /// <summary>
        /// Required if CorsRule element is present. A list of response headers to expose to CORS clients.
        /// </summary>
        public string[] ExposedHeaders { get; set; }

        /// <summary>
        /// Required if CorsRule element is present. A list of headers allowed to be part of the cross-origin request.
        /// </summary>
        public string[] AllowedHeaders { get; set; }
    }
}