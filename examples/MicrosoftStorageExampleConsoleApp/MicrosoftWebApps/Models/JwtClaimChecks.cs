using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the checks that should be made while validating the JWT Claims.
    /// </summary>
    public class JwtClaimChecks
    {
        /// <summary>
        /// The list of the allowed groups.
        /// </summary>
        public string[] AllowedGroups { get; set; }

        /// <summary>
        /// The list of the allowed client applications.
        /// </summary>
        public string[] AllowedClientApplications { get; set; }
    }
}