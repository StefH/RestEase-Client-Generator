using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class KeyVaultProperties
    {
        /// <summary>
        /// Key vault uri to access the encryption key.
        /// </summary>
        public string KeyIdentifier { get; set; }

        /// <summary>
        /// The client ID of the identity which will be used to access key vault.
        /// </summary>
        public string Identity { get; set; }
    }
}