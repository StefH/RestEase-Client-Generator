using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class StorageAccountListResult
    {
        public StorageAccount[] Value { get; set; }

        public string NextLink { get; set; }
    }
}