using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Managed service identity.
    /// </summary>
    public class ManagedServiceIdentity
    {
        /// <summary>
        /// Type of managed service identity.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Tenant of managed service identity.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// Principal Id of managed service identity.
        /// </summary>
        public string PrincipalId { get; set; }

        /// <summary>
        /// The list of user assigned identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
        /// </summary>
        public Dictionary<string, UserAssignedIdentity> UserAssignedIdentities { get; set; }
    }
}