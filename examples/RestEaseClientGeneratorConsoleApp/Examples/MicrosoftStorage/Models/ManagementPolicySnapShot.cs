using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Management policy action for snapshot.
    /// </summary>
    public class ManagementPolicySnapShot
    {
        /// <summary>
        /// not-used
        /// </summary>
        public DateAfterCreation TierToCool { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public DateAfterCreation TierToArchive { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public DateAfterCreation Delete { get; set; }
    }
}