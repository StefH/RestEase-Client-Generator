using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// SnapshotRestoreRequest resource specific properties
    /// </summary>
    public class SnapshotRestoreRequestProperties
    {
        /// <summary>
        /// Point in time in which the app restore should be done, formatted as a DateTime string.
        /// </summary>
        public string SnapshotTime { get; set; }

        /// <summary>
        /// Specifies the web app that snapshot contents will be retrieved from.
        /// </summary>
        public SnapshotRecoverySource RecoverySource { get; set; }

        /// <summary>
        /// If true the restore operation can overwrite source app; otherwise, false.
        /// </summary>
        public bool Overwrite { get; set; }

        /// <summary>
        /// If true, site configuration, in addition to content, will be reverted.
        /// </summary>
        public bool RecoverConfiguration { get; set; }

        /// <summary>
        /// If true, custom hostname conflicts will be ignored when recovering to a target web app.This setting is only necessary when RecoverConfiguration is enabled.
        /// </summary>
        public bool IgnoreConflictingHostNames { get; set; }

        /// <summary>
        /// If true, the snapshot is retrieved from DRSecondary endpoint.
        /// </summary>
        public bool UseDRSecondary { get; set; }
    }
}