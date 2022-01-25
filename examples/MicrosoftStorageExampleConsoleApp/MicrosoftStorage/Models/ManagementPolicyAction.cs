using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Actions are applied to the filtered blobs when the execution condition is met.
    /// </summary>
    public class ManagementPolicyAction
    {
        /// <summary>
        /// Management policy action for base blob.
        /// </summary>
        public ManagementPolicyBaseBlob BaseBlob { get; set; }

        /// <summary>
        /// Management policy action for snapshot.
        /// </summary>
        public ManagementPolicySnapShot Snapshot { get; set; }

        /// <summary>
        /// Management policy action for blob version.
        /// </summary>
        public ManagementPolicyVersion Version { get; set; }
    }
}