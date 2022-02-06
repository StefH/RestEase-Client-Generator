using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// User Assigned identity.
    /// </summary>
    public class UserAssignedIdentity
    {
        /// <summary>
        /// Principal Id of user assigned identity
        /// </summary>
        public string PrincipalId { get; set; }

        /// <summary>
        /// Client Id of user assigned identity
        /// </summary>
        public string ClientId { get; set; }
    }
}