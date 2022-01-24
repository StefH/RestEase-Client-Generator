using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// Actions are applied to the filtered blobs when the execution condition is met.
    /// </summary>
    public class ManagementPolicyAction
    {
        /// <summary>
        /// not-used
        /// </summary>
        public ManagementPolicyBaseBlob BaseBlob { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ManagementPolicySnapShot Snapshot { get; set; }
    }
}