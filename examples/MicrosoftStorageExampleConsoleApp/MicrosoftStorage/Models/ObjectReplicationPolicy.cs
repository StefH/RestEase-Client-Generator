using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The replication policy between two storage accounts. Multiple rules can be defined in one policy.
    /// </summary>
    public class ObjectReplicationPolicy : Resource 
    {
        /// <summary>
        /// The Storage Account ObjectReplicationPolicy properties.
        /// </summary>
        public ObjectReplicationPolicyProperties Properties { get; set; }

    }
}