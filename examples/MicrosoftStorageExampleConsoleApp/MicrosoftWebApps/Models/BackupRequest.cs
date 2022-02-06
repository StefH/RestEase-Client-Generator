using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Description of a backup which will be performed.
    /// </summary>
    public class BackupRequest : ProxyOnlyResource
    {
        /// <summary>
        /// BackupRequest resource specific properties
        /// </summary>
        public BackupRequestProperties Properties { get; set; }

    }
}