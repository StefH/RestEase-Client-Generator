using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the Azure Active Directory token validation flow.
    /// </summary>
    public class AzureActiveDirectoryValidation
    {
        /// <summary>
        /// The configuration settings of the checks that should be made while validating the JWT Claims.
        /// </summary>
        public JwtClaimChecks JwtClaimChecks { get; set; }

        /// <summary>
        /// The list of audiences that can make successful authentication/authorization requests.
        /// </summary>
        public string[] AllowedAudiences { get; set; }

        /// <summary>
        /// The configuration settings of the Azure Active Directory default authorization policy.
        /// </summary>
        public DefaultAuthorizationPolicy DefaultAuthorizationPolicy { get; set; }
    }
}