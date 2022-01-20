using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class ObjectReplicationPolicyFilter
    {
        public string[] PrefixMatch { get; set; }

        public string MinCreationTime { get; set; }
    }
}