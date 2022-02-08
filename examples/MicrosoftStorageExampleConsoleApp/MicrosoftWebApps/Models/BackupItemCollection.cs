using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of backup items.
    /// </summary>
    public class BackupItemCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public BackupItem[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}