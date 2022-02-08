using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// BackupRequest resource specific properties
    /// </summary>
    public class BackupRequestProperties
    {
        /// <summary>
        /// Name of the backup.
        /// </summary>
        public string BackupName { get; set; }

        /// <summary>
        /// True if the backup schedule is enabled (must be included in that case), false if the backup schedule should be disabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// SAS URL to the container.
        /// </summary>
        public string StorageAccountUrl { get; set; }

        /// <summary>
        /// Description of a backup schedule. Describes how often should be the backup performed and what should be the retention policy.
        /// </summary>
        public BackupSchedule BackupSchedule { get; set; }

        /// <summary>
        /// Databases included in the backup.
        /// </summary>
        public DatabaseBackupSetting[] Databases { get; set; }
    }
}