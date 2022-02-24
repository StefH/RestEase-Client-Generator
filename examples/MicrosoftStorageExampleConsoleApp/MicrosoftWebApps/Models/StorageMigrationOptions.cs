using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Options for app content migration.
    /// </summary>
    public class StorageMigrationOptions : ProxyOnlyResource 
    {
        /// <summary>
        /// StorageMigrationOptions resource specific properties
        /// </summary>
        public StorageMigrationOptionsProperties Properties { get; set; }

    }
}