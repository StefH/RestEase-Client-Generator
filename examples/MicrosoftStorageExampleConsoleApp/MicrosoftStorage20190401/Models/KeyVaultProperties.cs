using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// Properties of key vault.
    /// </summary>
    public class KeyVaultProperties
    {
        /// <summary>
        /// The name of KeyVault key.
        /// </summary>
        public string Keyname { get; set; }

        /// <summary>
        /// The version of KeyVault key.
        /// </summary>
        public string Keyversion { get; set; }

        /// <summary>
        /// The Uri of KeyVault.
        /// </summary>
        public string Keyvaulturi { get; set; }
    }
}