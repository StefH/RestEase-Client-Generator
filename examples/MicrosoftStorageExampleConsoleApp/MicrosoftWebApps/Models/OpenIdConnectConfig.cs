using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the endpoints used for the custom Open ID Connect provider.
    /// </summary>
    public class OpenIdConnectConfig
    {
        /// <summary>
        /// The endpoint to be used to make an authorization request.
        /// </summary>
        public string AuthorizationEndpoint { get; set; }

        /// <summary>
        /// The endpoint to be used to request a token.
        /// </summary>
        public string TokenEndpoint { get; set; }

        /// <summary>
        /// The endpoint that issues the token.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// The endpoint that provides the keys necessary to validate the token.
        /// </summary>
        public string CertificationUri { get; set; }

        /// <summary>
        /// The endpoint that contains all the configuration endpoints for the provider.
        /// </summary>
        public string WellKnownOpenIdConfiguration { get; set; }
    }
}