using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class EncryptionService
    {
        public bool Enabled { get; set; }

        public DateTime LastEnabledTime { get; set; }

        public string KeyType { get; set; }
    }
}