using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class ImmutableStorageAccount
    {
        public bool Enabled { get; set; }

        public AccountImmutabilityPolicyProperties ImmutabilityPolicy { get; set; }
    }
}