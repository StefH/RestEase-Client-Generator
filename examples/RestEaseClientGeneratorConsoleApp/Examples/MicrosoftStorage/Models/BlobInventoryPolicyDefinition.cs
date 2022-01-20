using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class BlobInventoryPolicyDefinition
    {
        public BlobInventoryPolicyFilter Filters { get; set; }

        public string Format { get; set; }

        public string Schedule { get; set; }

        public string ObjectType { get; set; }

        public string[] SchemaFields { get; set; }
    }
}