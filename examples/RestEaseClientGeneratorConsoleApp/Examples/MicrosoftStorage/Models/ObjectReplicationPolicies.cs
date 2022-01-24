using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// List storage account object replication policies.
    /// </summary>
    public class ObjectReplicationPolicies
    {
        /// <summary>
        /// The replication policy between two storage accounts.
        /// </summary>
        public ObjectReplicationPolicy[] Value { get; set; }
    }
}