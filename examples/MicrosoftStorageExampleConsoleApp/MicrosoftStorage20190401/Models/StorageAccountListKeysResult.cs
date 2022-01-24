using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// The response from the ListKeys operation.
    /// </summary>
    public class StorageAccountListKeysResult
    {
        /// <summary>
        /// Gets the list of storage account keys and their properties for the specified storage account.
        /// </summary>
        public StorageAccountKey[] Keys { get; set; }
    }
}