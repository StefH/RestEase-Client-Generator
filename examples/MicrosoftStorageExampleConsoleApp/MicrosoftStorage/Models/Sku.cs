using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class Sku
    {
        public string Name { get; set; }

        public string Tier { get; set; }

        public string Size { get; set; }

        public string Family { get; set; }

        public int Capacity { get; set; }
    }
}