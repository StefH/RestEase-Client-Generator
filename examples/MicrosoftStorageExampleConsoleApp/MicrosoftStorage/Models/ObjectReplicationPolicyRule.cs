using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The replication policy rule between two containers.
    /// </summary>
    public class ObjectReplicationPolicyRule
    {
        /// <summary>
        /// Rule Id is auto-generated for each new rule on destination account. It is required for put policy on source account.
        /// </summary>
        public string RuleId { get; set; }

        /// <summary>
        /// Required. Source container name.
        /// </summary>
        public string SourceContainer { get; set; }

        /// <summary>
        /// Required. Destination container name.
        /// </summary>
        public string DestinationContainer { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ObjectReplicationPolicyFilter Filters { get; set; }
    }
}