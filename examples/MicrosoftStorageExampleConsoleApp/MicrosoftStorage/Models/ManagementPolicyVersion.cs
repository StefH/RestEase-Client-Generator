using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Management policy action for blob version.
    /// </summary>
    public class ManagementPolicyVersion
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