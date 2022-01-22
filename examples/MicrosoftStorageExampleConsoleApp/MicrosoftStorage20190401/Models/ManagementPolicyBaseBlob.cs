using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    public class ManagementPolicyBaseBlob
    {
        public DateAfterModification TierToCool { get; set; }

        public DateAfterModification TierToArchive { get; set; }

        public DateAfterModification Delete { get; set; }
    }
}