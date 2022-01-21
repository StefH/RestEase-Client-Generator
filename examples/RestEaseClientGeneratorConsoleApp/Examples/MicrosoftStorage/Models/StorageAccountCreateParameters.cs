using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class StorageAccountCreateParameters
    {
        // public DefinitionsSku Sku { get; set; }

        public string Kind { get; set; }

        public string Location { get; set; }

        public ExtendedLocation ExtendedLocation { get; set; }

        public object Tags { get; set; }

        public Identity Identity { get; set; }

        public StorageAccountPropertiesCreateParameters Properties { get; set; }
    }
}