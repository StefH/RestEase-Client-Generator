using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class StorageAccountUpdateParameters
    {
        // public DefinitionsSku Sku { get; set; }

        public object Tags { get; set; }

        public Identity Identity { get; set; }

        public StorageAccountPropertiesUpdateParameters Properties { get; set; }

        public string Kind { get; set; }
    }
}