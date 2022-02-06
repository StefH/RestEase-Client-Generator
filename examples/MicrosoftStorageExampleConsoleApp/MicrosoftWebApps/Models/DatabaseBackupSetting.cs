using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Database backup settings.
    /// </summary>
    public class DatabaseBackupSetting
    {
        /// <summary>
        /// Database type (e.g. SqlAzure / MySql).
        /// </summary>
        public string DatabaseType { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Contains a connection string name that is linked to the SiteConfig.ConnectionStrings.This is used during restore with overwrite connection strings options.
        /// </summary>
        public string ConnectionStringName { get; set; }

        /// <summary>
        /// Contains a connection string to a database which is being backed up or restored. If the restore should happen to a new database, the database name inside is the new one.
        /// </summary>
        public string ConnectionString { get; set; }
    }
}