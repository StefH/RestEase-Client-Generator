using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The Storage Account ManagementPolicy properties.
    /// </summary>
    public class ManagementPolicyProperties
    {
        /// <summary>
        /// Returns the date and time the ManagementPolicies was last modified.
        /// </summary>
        public DateTime LastModifiedTime { get; set; }

        /// <summary>
        /// The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
        /// </summary>
        public ManagementPolicySchema Policy { get; set; }
    }
}