using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// MigrateMySqlStatus resource specific properties
    /// </summary>
    public class MigrateMySqlStatusProperties
    {
        /// <summary>
        /// Status of the migration task.
        /// </summary>
        public string MigrationOperationStatus { get; set; }

        /// <summary>
        /// Operation ID for the migration task.
        /// </summary>
        public string OperationId { get; set; }

        /// <summary>
        /// True if the web app has in app MySql enabled
        /// </summary>
        public bool LocalMySqlEnabled { get; set; }
    }
}