using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class ObjectReplicationPolicyRule
    {
        public string RuleId { get; set; }

        public string SourceContainer { get; set; }

        public string DestinationContainer { get; set; }

        public ObjectReplicationPolicyFilter Filters { get; set; }
    }
}