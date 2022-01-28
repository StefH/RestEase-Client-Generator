using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Identity for the resource.
    /// </summary>
    public class Identity
    {
        /// <summary>
        /// The principal ID of resource identity.
        /// </summary>
        public string PrincipalId { get; set; }

        /// <summary>
        /// The tenant ID of resource.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The identity type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a list of key value pairs that describe the set of User Assigned identities that will be used with this storage account. The key is the ARM resource identifier of the identity. Only 1 User Assigned identity is permitted here.
        /// </summary>
        public Dictionary<string, UserAssignedIdentity> UserAssignedIdentities { get; set; }
    }
}