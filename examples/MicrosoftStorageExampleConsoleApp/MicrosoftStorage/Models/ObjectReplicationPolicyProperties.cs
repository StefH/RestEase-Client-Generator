using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class ObjectReplicationPolicyProperties
    {
        public string PolicyId { get; set; }

        public DateTime EnabledTime { get; set; }

        public string SourceAccount { get; set; }

        public string DestinationAccount { get; set; }

        public ObjectReplicationPolicyRule[] Rules { get; set; }
    }
}