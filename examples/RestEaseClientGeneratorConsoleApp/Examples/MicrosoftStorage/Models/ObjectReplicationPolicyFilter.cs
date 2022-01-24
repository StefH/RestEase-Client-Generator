using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Filters limit replication to a subset of blobs within the storage account. A logical OR is performed on values in the filter. If multiple filters are defined, a logical AND is performed on all filters.
    /// </summary>
    public class ObjectReplicationPolicyFilter
    {
        /// <summary>
        /// Optional. Filters the results to replicate only blobs whose names begin with the specified prefix.
        /// </summary>
        public string[] PrefixMatch { get; set; }

        /// <summary>
        /// Blobs created after the time will be replicated to the destination. It must be in datetime format 'yyyy-MM-ddTHH:mm:ssZ'. Example: 2020-02-19T16:05:00Z
        /// </summary>
        public string MinCreationTime { get; set; }
    }
}