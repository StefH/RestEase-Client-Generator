using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// SiteAuthSettingsV2 resource specific properties
    /// </summary>
    public class SiteAuthSettingsV2Properties
    {
        /// <summary>
        /// The configuration settings of the platform of App Service Authentication/Authorization.
        /// </summary>
        public AuthPlatform Platform { get; set; }

        /// <summary>
        /// The configuration settings that determines the validation flow of users using App Service Authentication/Authorization.
        /// </summary>
        public GlobalValidation GlobalValidation { get; set; }

        /// <summary>
        /// The configuration settings of each of the identity providers used to configure App Service Authentication/Authorization.
        /// </summary>
        public IdentityProviders IdentityProviders { get; set; }

        /// <summary>
        /// The configuration settings of the login flow of users using App Service Authentication/Authorization.
        /// </summary>
        public Login Login { get; set; }

        /// <summary>
        /// The configuration settings of the HTTP requests for authentication and authorization requests made against App Service Authentication/Authorization.
        /// </summary>
        public HttpSettings HttpSettings { get; set; }
    }
}