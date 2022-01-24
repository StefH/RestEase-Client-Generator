using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Attributes of a deleted storage account.
    /// </summary>
    public class DeletedAccountProperties
    {
        /// <summary>
        /// Full resource id of the original storage account.
        /// </summary>
        public string StorageAccountResourceId { get; set; }

        /// <summary>
        /// Location of the deleted account.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Can be used to attempt recovering this deleted account via PutStorageAccount API.
        /// </summary>
        public string RestoreReference { get; set; }

        /// <summary>
        /// Creation time of the deleted account.
        /// </summary>
        public string CreationTime { get; set; }

        /// <summary>
        /// Deletion time of the deleted account.
        /// </summary>
        public string DeletionTime { get; set; }
    }
}