using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// Management policy action for snapshot.
    /// </summary>
    public class ManagementPolicySnapShot
    {
        /// <summary>
        /// Object to define the number of days after creation.
        /// </summary>
        public DateAfterCreation Delete { get; set; }
    }
}