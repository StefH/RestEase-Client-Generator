using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the Allowed Audiences validation flow.
    /// </summary>
    public class AllowedAudiencesValidation
    {
        /// <summary>
        /// The configuration settings of the allowed list of audiences from which to validate the JWT token.
        /// </summary>
        public string[] AllowedAudiences { get; set; }
    }
}