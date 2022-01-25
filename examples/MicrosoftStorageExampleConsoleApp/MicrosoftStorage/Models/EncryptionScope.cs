using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The Encryption Scope resource.
    /// </summary>
    public class EncryptionScope : Resource
    {
        /// <summary>
        /// Properties of the encryption scope.
        /// </summary>
        public EncryptionScopeProperties Properties { get; set; }

    }
}