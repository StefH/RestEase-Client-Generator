using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// BackupItem resource specific properties
    /// </summary>
    public class BackupItemProperties
    {
        /// <summary>
        /// Id of the backup.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// SAS URL for the storage account container which contains this backup.
        /// </summary>
        public string StorageAccountUrl { get; set; }

        /// <summary>
        /// Name of the blob which contains data for this backup.
        /// </summary>
        public string BlobName { get; set; }

        /// <summary>
        /// Name of this backup.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Backup status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Size of the backup in bytes.
        /// </summary>
        public long SizeInBytes { get; set; }

        /// <summary>
        /// Timestamp of the backup creation.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Details regarding this backup. Might contain an error message.
        /// </summary>
        public string Log { get; set; }

        /// <summary>
        /// List of databases included in the backup.
        /// </summary>
        public DatabaseBackupSetting[] Databases { get; set; }

        /// <summary>
        /// True if this backup has been created due to a schedule being triggered.
        /// </summary>
        public bool Scheduled { get; set; }

        /// <summary>
        /// Timestamp of a last restore operation which used this backup.
        /// </summary>
        public DateTime LastRestoreTimeStamp { get; set; }

        /// <summary>
        /// Timestamp when this backup finished.
        /// </summary>
        public DateTime FinishedTimeStamp { get; set; }

        /// <summary>
        /// Unique correlation identifier. Please use this along with the timestamp while communicating with Azure support.
        /// </summary>
        public string CorrelationId { get; set; }

        /// <summary>
        /// Size of the original web app which has been backed up.
        /// </summary>
        public long WebsiteSizeInBytes { get; set; }
    }
}