using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// Identity for the container group.
    /// </summary>
    public class ContainerGroupIdentity
    {
        /// <summary>
        /// The principal id of the container group identity. This property will only be provided for a system assigned identity.
        /// </summary>
        public string PrincipalId { get; set; }

        /// <summary>
        /// The tenant id associated with the container group. This property will only be provided for a system assigned identity.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The type of identity used for the container group. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities. The type 'None' will remove any identities from the container group.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The list of user identities associated with the container group. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        public ContainerGroupIdentityUserAssignedIdentities UserAssignedIdentities { get; set; }
    }
}