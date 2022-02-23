using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// AzureStorageInfo dictionary resource.
    /// </summary>
    public class AzureStoragePropertyDictionaryResource : ProxyOnlyResource 
    {
        /// <summary>
        /// Azure storage accounts.
        /// </summary>
        public Dictionary<string, AzureStorageInfoValue> Properties { get; set; }

    }
}