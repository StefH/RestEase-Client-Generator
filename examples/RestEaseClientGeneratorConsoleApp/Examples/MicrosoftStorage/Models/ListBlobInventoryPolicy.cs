using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// List of blob inventory policies returned.
    /// </summary>
    public class ListBlobInventoryPolicy
    {
        /// <summary>
        /// List of blob inventory policies.
        /// </summary>
        public BlobInventoryPolicy[] Value { get; set; }
    }
}