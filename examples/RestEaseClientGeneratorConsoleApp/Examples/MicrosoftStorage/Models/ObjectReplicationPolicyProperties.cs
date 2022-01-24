using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The Storage Account ObjectReplicationPolicy properties.
    /// </summary>
    public class ObjectReplicationPolicyProperties
    {
        /// <summary>
        /// A unique id for object replication policy.
        /// </summary>
        public string PolicyId { get; set; }

        /// <summary>
        /// Indicates when the policy is enabled on the source account.
        /// </summary>
        public DateTime EnabledTime { get; set; }

        /// <summary>
        /// Required. Source account name. It should be full resource id if allowCrossTenantReplication set to false.
        /// </summary>
        public string SourceAccount { get; set; }

        /// <summary>
        /// Required. Destination account name. It should be full resource id if allowCrossTenantReplication set to false.
        /// </summary>
        public string DestinationAccount { get; set; }

        /// <summary>
        /// The storage account object replication rules.
        /// </summary>
        public ObjectReplicationPolicyRule[] Rules { get; set; }
    }
}