using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class BlobInventoryPolicyFilter
    {
        public string[] PrefixMatch { get; set; }

        public string[] BlobTypes { get; set; }

        public bool IncludeBlobVersions { get; set; }

        public bool IncludeSnapshots { get; set; }
    }
}