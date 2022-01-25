using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    public class ContainerGroupIdentityUserAssignedIdentities
    {
        /// <summary>
        /// The principal id of user assigned identity.
        /// </summary>
        public string PrincipalId { get; set; }

        /// <summary>
        /// The client id of user assigned identity.
        /// </summary>
        public string ClientId { get; set; }
    }
}