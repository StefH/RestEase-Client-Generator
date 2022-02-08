using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Description of a backup schedule. Describes how often should be the backup performed and what should be the retention policy.
    /// </summary>
    public class BackupSchedule
    {
        /// <summary>
        /// How often the backup should be executed (e.g. for weekly backup, this should be set to 7 and FrequencyUnit should be set to Day)
        /// </summary>
        public int FrequencyInterval { get; set; }

        /// <summary>
        /// The unit of time for how often the backup should be executed (e.g. for weekly backup, this should be set to Day and FrequencyInterval should be set to 7)
        /// </summary>
        public string FrequencyUnit { get; set; }

        /// <summary>
        /// True if the retention policy should always keep at least one backup in the storage account, regardless how old it is; false otherwise.
        /// </summary>
        public bool KeepAtLeastOneBackup { get; set; }

        /// <summary>
        /// After how many days backups should be deleted.
        /// </summary>
        public int RetentionPeriodInDays { get; set; }

        /// <summary>
        /// When the schedule should start working.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Last time when this schedule was triggered.
        /// </summary>
        public DateTime LastExecutionTime { get; set; }
    }
}