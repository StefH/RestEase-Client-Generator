using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Statistics related to replication for storage account's Blob, Table, Queue and File services. It is only available when geo-redundant replication is enabled for the storage account.
    /// </summary>
    public class GeoReplicationStats
    {
        /// <summary>
        /// The status of the secondary location. Possible values are: - Live: Indicates that the secondary location is active and operational. - Bootstrap: Indicates initial synchronization from the primary location to the secondary location is in progress.This typically occurs when replication is first enabled. - Unavailable: Indicates that the secondary location is temporarily unavailable.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// All primary writes preceding this UTC date/time value are guaranteed to be available for read operations. Primary writes following this point in time may or may not be available for reads. Element may be default value if value of LastSyncTime is not available, this can happen if secondary is offline or we are in bootstrap.
        /// </summary>
        public DateTime LastSyncTime { get; set; }

        /// <summary>
        /// A boolean flag which indicates whether or not account failover is supported for the account.
        /// </summary>
        public bool CanFailover { get; set; }
    }
}