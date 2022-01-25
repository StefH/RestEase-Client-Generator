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
        /// Object to define the number of days after last modification.
        /// </summary>
        public DateAfterModification TierToCool { get; set; }

        /// <summary>
        /// Object to define the number of days after last modification.
        /// </summary>
        public DateAfterModification TierToArchive { get; set; }

        /// <summary>
        /// Object to define the number of days after last modification.
        /// </summary>
        public DateAfterModification Delete { get; set; }
    }
}