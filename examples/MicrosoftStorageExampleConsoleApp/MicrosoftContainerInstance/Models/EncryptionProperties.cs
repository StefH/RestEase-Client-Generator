using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The container group encryption properties.
    /// </summary>
    [FluentBuilder.AutoGenerateBuilder]
    public class EncryptionProperties
    {
        /// <summary>
        /// The keyvault base url.
        /// </summary>
        public string VaultBaseUrl { get; set; }

        /// <summary>
        /// The encryption key name.
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// The encryption key version.
        /// </summary>
        public string KeyVersion { get; set; }
    }
}