using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class EncryptionScopeListResult
    {
        public EncryptionScope[] Value { get; set; }

        public string NextLink { get; set; }
    }
}