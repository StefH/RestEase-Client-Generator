using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
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
        /// An array of predefined enum values. Only blockBlob is supported.
        /// </summary>
        public string[] BlobTypes { get; set; }
    }
}