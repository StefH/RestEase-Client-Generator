using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Details about app recovery operation.
    /// </summary>
    public class SnapshotRestoreRequest : ProxyOnlyResource
    {
        /// <summary>
        /// SnapshotRestoreRequest resource specific properties
        /// </summary>
        public SnapshotRestoreRequestProperties Properties { get; set; }

    }
}