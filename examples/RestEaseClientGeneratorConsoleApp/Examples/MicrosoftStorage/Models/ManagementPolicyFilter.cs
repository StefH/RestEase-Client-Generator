using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Filters limit rule actions to a subset of blobs within the storage account. If multiple filters are defined, a logical AND is performed on all filters. 
    /// </summary>
    public class ManagementPolicyFilter
    {
        /// <summary>
        /// An array of strings for prefixes to be match.
        /// </summary>
        public string[] PrefixMatch { get; set; }

        /// <summary>
        /// An array of predefined enum values. Currently blockBlob supports all tiering and delete actions. Only delete actions are supported for appendBlob.
        /// </summary>
        public string[] BlobTypes { get; set; }

        /// <summary>
        /// An array of blob index tag based filters, there can be at most 10 tag filters
        /// </summary>
        public TagFilter[] BlobIndexMatch { get; set; }
    }
}