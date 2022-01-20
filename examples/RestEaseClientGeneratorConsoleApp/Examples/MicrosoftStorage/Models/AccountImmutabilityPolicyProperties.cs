using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class AccountImmutabilityPolicyProperties
    {
        public int ImmutabilityPeriodSinceCreationInDays { get; set; }

        public string State { get; set; }

        public bool AllowProtectedAppendWrites { get; set; }
    }
}