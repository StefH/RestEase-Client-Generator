using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    public class StorageAccount : TrackedResource
    {
        public Sku Sku { get; set; }

        public string Kind { get; set; }

        public Identity Identity { get; set; }

        public StorageAccountProperties Properties { get; set; }

    }
}