using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// SiteConfigurationSnapshotInfo resource specific properties
    /// </summary>
    public class SiteConfigurationSnapshotInfoProperties
    {
        /// <summary>
        /// The time the snapshot was taken.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// The id of the snapshot
        /// </summary>
        public int SnapshotId { get; set; }
    }
}