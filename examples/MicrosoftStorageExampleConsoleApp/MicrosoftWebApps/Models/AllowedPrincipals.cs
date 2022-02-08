using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the Azure Active Directory allowed principals.
    /// </summary>
    public class AllowedPrincipals
    {
        /// <summary>
        /// The list of the allowed groups.
        /// </summary>
        public string[] Groups { get; set; }

        /// <summary>
        /// The list of the allowed identities.
        /// </summary>
        public string[] Identities { get; set; }
    }
}