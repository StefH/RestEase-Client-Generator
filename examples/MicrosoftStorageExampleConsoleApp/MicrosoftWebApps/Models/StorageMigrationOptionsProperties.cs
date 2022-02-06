using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// StorageMigrationOptions resource specific properties
    /// </summary>
    public class StorageMigrationOptionsProperties
    {
        /// <summary>
        /// AzureFiles connection string.
        /// </summary>
        public string AzurefilesConnectionString { get; set; }

        /// <summary>
        /// AzureFiles share.
        /// </summary>
        public string AzurefilesShare { get; set; }

        /// <summary>
        /// trueif the app should be switched over; otherwise, false.
        /// </summary>
        public bool SwitchSiteAfterMigration { get; set; }

        /// <summary>
        /// true if the app should be read only during copy operation; otherwise, false.
        /// </summary>
        public bool BlockWriteAccessToSite { get; set; }
    }
}