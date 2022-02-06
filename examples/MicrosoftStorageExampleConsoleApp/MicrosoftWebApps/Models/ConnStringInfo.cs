using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Database connection string information.
    /// </summary>
    public class ConnStringInfo
    {
        /// <summary>
        /// Name of connection string.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Connection string value.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Type of database.
        /// </summary>
        public string Type { get; set; }
    }
}