using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
    /// </summary>
    public class ManagementPolicySchema
    {
        /// <summary>
        /// The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
        /// </summary>
        public ManagementPolicyRule[] Rules { get; set; }
    }
}