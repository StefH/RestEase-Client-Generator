using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
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

        /// <summary>
        /// not-used
        /// </summary>
        public ManagementPolicyVersion Version { get; set; }
    }
}