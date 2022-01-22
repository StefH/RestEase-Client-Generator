using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class ManagementPolicyFilter
    {
        public string[] PrefixMatch { get; set; }

        public string[] BlobTypes { get; set; }

        public TagFilter[] BlobIndexMatch { get; set; }
    }
}