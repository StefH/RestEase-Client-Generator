using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The storage account blob inventory policy.
    /// </summary>
    public class BlobInventoryPolicy : Resource
    {
        /// <summary>
        /// The storage account blob inventory policy properties.
        /// </summary>
        public BlobInventoryPolicyProperties Properties { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public SystemData SystemData { get; set; }

    }
}