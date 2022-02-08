using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// MigrateMySqlRequest resource specific properties
    /// </summary>
    public class MigrateMySqlRequestProperties
    {
        /// <summary>
        /// Connection string to the remote MySQL database.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// The type of migration operation to be done
        /// </summary>
        public string MigrationType { get; set; }
    }
}