using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class DeletedAccountProperties
    {
        public string StorageAccountResourceId { get; set; }

        public string Location { get; set; }

        public string RestoreReference { get; set; }

        public string CreationTime { get; set; }

        public string DeletionTime { get; set; }
    }
}