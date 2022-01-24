using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
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
        /// Identity for the resource.
        /// </summary>
        public UserAssignedIdentities UserAssignedIdentities { get; set; }
    }
}