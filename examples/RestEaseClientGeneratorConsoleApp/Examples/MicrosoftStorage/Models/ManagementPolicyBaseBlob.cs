using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class ManagementPolicyBaseBlob
    {
        public DateAfterModification TierToCool { get; set; }

        public DateAfterModification TierToArchive { get; set; }

        public DateAfterModification Delete { get; set; }

        public bool EnableAutoTierToHotFromCool { get; set; }
    }
}