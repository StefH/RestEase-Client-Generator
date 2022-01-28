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
        /// Object to define the number of days after creation.
        /// </summary>
        public DateAfterCreation TierToCool { get; set; }

        /// <summary>
        /// Object to define the number of days after creation.
        /// </summary>
        public DateAfterCreation TierToArchive { get; set; }

        /// <summary>
        /// Object to define the number of days after creation.
        /// </summary>
        public DateAfterCreation Delete { get; set; }
    }
}