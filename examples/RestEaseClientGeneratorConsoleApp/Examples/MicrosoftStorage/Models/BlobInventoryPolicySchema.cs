using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The storage account blob inventory policy rules.
    /// </summary>
    public class BlobInventoryPolicySchema
    {
        /// <summary>
        /// Policy is enabled if set to true.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The valid value is Inventory
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The storage account blob inventory policy rules. The rule is applied when it is enabled.
        /// </summary>
        public BlobInventoryPolicyRule[] Rules { get; set; }
    }
}