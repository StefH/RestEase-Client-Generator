using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// UserAssignedIdentity for the resource.
    /// </summary>
    public class UserAssignedIdentity
    {
        /// <summary>
        /// The principal ID of the identity.
        /// </summary>
        public string PrincipalId { get; set; }

        /// <summary>
        /// The client ID of the identity.
        /// </summary>
        public string ClientId { get; set; }
    }
}