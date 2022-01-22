using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    public class ManagementPolicySnapShot
    {
        public DateAfterCreation TierToCool { get; set; }

        public DateAfterCreation TierToArchive { get; set; }

        public DateAfterCreation Delete { get; set; }
    }
}