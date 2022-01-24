using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Encryption identity for the storage account.
    /// </summary>
    public class EncryptionIdentity
    {
        /// <summary>
        /// Resource identifier of the UserAssigned identity to be associated with server-side encryption on the storage account.
        /// </summary>
        public string UserAssignedIdentity { get; set; }

        /// <summary>
        /// ClientId of the multi-tenant application to be used in conjunction with the user-assigned identity for cross-tenant customer-managed-keys server-side encryption on the storage account.
        /// </summary>
        public string FederatedIdentityClientId { get; set; }
    }
}