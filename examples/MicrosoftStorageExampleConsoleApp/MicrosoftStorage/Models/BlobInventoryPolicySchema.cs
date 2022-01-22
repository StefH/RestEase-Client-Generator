using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class BlobInventoryPolicySchema
    {
        public bool Enabled { get; set; }

        public string Type { get; set; }

        public BlobInventoryPolicyRule[] Rules { get; set; }
    }
}