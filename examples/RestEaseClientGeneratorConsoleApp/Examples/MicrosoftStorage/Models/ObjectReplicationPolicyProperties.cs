using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class ObjectReplicationPolicyProperties
    {
        public string PolicyId { get; set; }

        public DateTime EnabledTime { get; set; }

        public string SourceAccount { get; set; }

        public string DestinationAccount { get; set; }

        public object[] Rules { get; set; }
    }
}