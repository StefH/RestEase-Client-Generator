using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// An object that wraps the blob inventory rule. Each rule is uniquely defined by name.
    /// </summary>
    public class BlobInventoryPolicyRule
    {
        /// <summary>
        /// Rule is enabled when set to true.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Container name where blob inventory files are stored. Must be pre-created.
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// An object that defines the blob inventory rule.
        /// </summary>
        public BlobInventoryPolicyDefinition Definition { get; set; }
    }
}