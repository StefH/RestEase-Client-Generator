using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings that determines the validation flow of users using App Service Authentication/Authorization.
    /// </summary>
    public class GlobalValidation
    {
        /// <summary>
        /// true if the authentication flow is required any request is made; otherwise, false.
        /// </summary>
        public bool RequireAuthentication { get; set; }

        /// <summary>
        /// The action to take when an unauthenticated client attempts to access the app.
        /// </summary>
        public string UnauthenticatedClientAction { get; set; }

        /// <summary>
        /// The default authentication provider to use when multiple providers are configured.This setting is only needed if multiple providers are configured and the unauthenticated clientaction is set to "RedirectToLoginPage".
        /// </summary>
        public string RedirectToProvider { get; set; }

        /// <summary>
        /// The paths for which unauthenticated flow would not be redirected to the login page.
        /// </summary>
        public string[] ExcludedPaths { get; set; }
    }
}