using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the login flow of users using App Service Authentication/Authorization.
    /// </summary>
    public class Login
    {
        /// <summary>
        /// The routes that specify the endpoints used for login and logout requests.
        /// </summary>
        public LoginRoutes Routes { get; set; }

        /// <summary>
        /// The configuration settings of the token store.
        /// </summary>
        public TokenStore TokenStore { get; set; }

        /// <summary>
        /// true if the fragments from the request are preserved after the login request is made; otherwise, false.
        /// </summary>
        public bool PreserveUrlFragmentsForLogins { get; set; }

        /// <summary>
        /// External URLs that can be redirected to as part of logging in or logging out of the app. Note that the query string part of the URL is ignored.This is an advanced setting typically only needed by Windows Store application backends.Note that URLs within the current domain are always implicitly allowed.
        /// </summary>
        public string[] AllowedExternalRedirectUrls { get; set; }

        /// <summary>
        /// The configuration settings of the session cookie's expiration.
        /// </summary>
        public CookieExpiration CookieExpiration { get; set; }

        /// <summary>
        /// The configuration settings of the nonce used in the login flow.
        /// </summary>
        public Nonce Nonce { get; set; }
    }
}