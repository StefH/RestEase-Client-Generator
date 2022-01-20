using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    public class AzureFileVolume
    {
        public string ShareName { get; set; }

        public bool ReadOnly { get; set; }

        public string StorageAccountName { get; set; }

        public string StorageAccountKey { get; set; }
    }
}