using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Backup description.
    /// </summary>
    public class BackupItem : ProxyOnlyResource 
    {
        /// <summary>
        /// BackupItem resource specific properties
        /// </summary>
        public BackupItemProperties Properties { get; set; }

    }
}