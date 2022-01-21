using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class StorageAccountUpdateParameters
    {
        public Sku Sku { get; set; }

        public Identity Identity { get; set; }

        public StorageAccountPropertiesUpdateParameters Properties { get; set; }

        public string Kind { get; set; }
    }
}