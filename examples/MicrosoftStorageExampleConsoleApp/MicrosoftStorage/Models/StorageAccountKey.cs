using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class StorageAccountKey
    {
        public string KeyName { get; set; }

        public string Value { get; set; }

        public string Permissions { get; set; }

        public DateTime CreationTime { get; set; }
    }
}