using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// This property enables and defines account-level immutability. Enabling the feature auto-enables Blob Versioning.
    /// </summary>
    public class ImmutableStorageAccount
    {
        /// <summary>
        /// A boolean flag which enables account-level immutability. All the containers under such an account have object-level immutability enabled by default.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public AccountImmutabilityPolicyProperties ImmutabilityPolicy { get; set; }
    }
}