using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Blob restore parameters
    /// </summary>
    public class BlobRestoreParameters
    {
        /// <summary>
        /// Restore blob to the specified time.
        /// </summary>
        public DateTime TimeToRestore { get; set; }

        /// <summary>
        /// Blob ranges to restore.
        /// </summary>
        public BlobRestoreRange[] BlobRanges { get; set; }
    }
}