using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
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
        /// not-used
        /// </summary>
        public ManagementPolicySchema Policy { get; set; }
    }
}