using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class ImmutableStorageAccount
    {
        public bool Enabled { get; set; }

        public AccountImmutabilityPolicyProperties ImmutabilityPolicy { get; set; }
    }
}