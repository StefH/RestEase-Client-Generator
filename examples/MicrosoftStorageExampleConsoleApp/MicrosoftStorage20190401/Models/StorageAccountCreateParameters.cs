using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    public class StorageAccountCreateParameters
    {
        public Sku Sku { get; set; }

        public string Kind { get; set; }

        public string Location { get; set; }

        public Identity Identity { get; set; }

        public StorageAccountPropertiesCreateParameters Properties { get; set; }
    }
}