using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class BlobInventoryPolicyRule
    {
        public bool Enabled { get; set; }

        public string Name { get; set; }

        public string Destination { get; set; }

        public BlobInventoryPolicyDefinition Definition { get; set; }
    }
}