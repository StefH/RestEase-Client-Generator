using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// The parameters used to regenerate the storage account key.
    /// </summary>
    public class StorageAccountRegenerateKeyParameters
    {
        /// <summary>
        /// The name of storage keys that want to be regenerated, possible values are key1, key2, kerb1, kerb2.
        /// </summary>
        public string KeyName { get; set; }
    }
}