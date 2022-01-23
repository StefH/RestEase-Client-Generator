using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// Management policy action for base blob.
    /// </summary>
    public class ManagementPolicyBaseBlob
    {
        /// <summary>
        /// not-used
        /// </summary>
        public DateAfterModification TierToCool { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public DateAfterModification TierToArchive { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public DateAfterModification Delete { get; set; }
    }
}