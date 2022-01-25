using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Management policy action for base blob.
    /// </summary>
    public class ManagementPolicyBaseBlob
    {
        /// <summary>
        /// Object to define the number of days after object last modification Or last access. Properties daysAfterModificationGreaterThan and daysAfterLastAccessTimeGreaterThan are mutually exclusive.
        /// </summary>
        public DateAfterModification TierToCool { get; set; }

        /// <summary>
        /// Object to define the number of days after object last modification Or last access. Properties daysAfterModificationGreaterThan and daysAfterLastAccessTimeGreaterThan are mutually exclusive.
        /// </summary>
        public DateAfterModification TierToArchive { get; set; }

        /// <summary>
        /// Object to define the number of days after object last modification Or last access. Properties daysAfterModificationGreaterThan and daysAfterLastAccessTimeGreaterThan are mutually exclusive.
        /// </summary>
        public DateAfterModification Delete { get; set; }

        /// <summary>
        /// This property enables auto tiering of a blob from cool to hot on a blob access. This property requires tierToCool.daysAfterLastAccessTimeGreaterThan.
        /// </summary>
        public bool EnableAutoTierToHotFromCool { get; set; }
    }
}