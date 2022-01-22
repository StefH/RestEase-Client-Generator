using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class StorageAccountListResult
    {
        public StorageAccount[] Value { get; set; }

        public string NextLink { get; set; }
    }
}