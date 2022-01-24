using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
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

        /// <summary>
        /// This property enables auto tiering of a blob from cool to hot on a blob access. This property requires tierToCool.daysAfterLastAccessTimeGreaterThan.
        /// </summary>
        public bool EnableAutoTierToHotFromCool { get; set; }
    }
}