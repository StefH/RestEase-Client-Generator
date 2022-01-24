using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// The parameters used to check the availability of the storage account name.
    /// </summary>
    public class StorageAccountCheckNameAvailabilityParameters
    {
        /// <summary>
        /// The storage account name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of resource, Microsoft.Storage/storageAccounts
        /// </summary>
        public string Type { get; set; }
    }
}