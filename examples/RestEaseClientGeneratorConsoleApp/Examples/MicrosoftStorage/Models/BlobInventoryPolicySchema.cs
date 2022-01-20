using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class BlobInventoryPolicySchema
    {
        public bool Enabled { get; set; }

        public string Type { get; set; }

        public object[] Rules { get; set; }
    }
}