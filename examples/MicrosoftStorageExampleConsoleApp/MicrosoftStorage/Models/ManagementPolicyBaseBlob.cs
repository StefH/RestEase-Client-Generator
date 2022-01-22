using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class ManagementPolicyBaseBlob
    {
        public DateAfterModification TierToCool { get; set; }

        public DateAfterModification TierToArchive { get; set; }

        public DateAfterModification Delete { get; set; }

        public bool EnableAutoTierToHotFromCool { get; set; }
    }
}