using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// Blob restore status.
    /// </summary>
    public class BlobRestoreStatus
    {
        /// <summary>
        /// The status of blob restore progress. Possible values are: - InProgress: Indicates that blob restore is ongoing. - Complete: Indicates that blob restore has been completed successfully. - Failed: Indicates that blob restore is failed.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Failure reason when blob restore is failed.
        /// </summary>
        public string FailureReason { get; set; }

        /// <summary>
        /// Id for tracking blob restore request.
        /// </summary>
        public string RestoreId { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public BlobRestoreParameters Parameters { get; set; }
    }
}