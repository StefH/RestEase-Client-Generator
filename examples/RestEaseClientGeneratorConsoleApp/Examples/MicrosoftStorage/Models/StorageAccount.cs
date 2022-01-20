using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class StorageAccount
    {
       // public DefinitionsSku Sku { get; set; }

        public string Kind { get; set; }

        public Identity Identity { get; set; }

        public ExtendedLocation ExtendedLocation { get; set; }

        public StorageAccountProperties Properties { get; set; }
    }
}