using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the Azure Active Directory default authorization policy.
    /// </summary>
    public class DefaultAuthorizationPolicy
    {
        /// <summary>
        /// The configuration settings of the Azure Active Directory allowed principals.
        /// </summary>
        public AllowedPrincipals AllowedPrincipals { get; set; }

        /// <summary>
        /// The configuration settings of the Azure Active Directory allowed applications.
        /// </summary>
        public string[] AllowedApplications { get; set; }
    }
}