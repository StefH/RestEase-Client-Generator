using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Application logs to Azure table storage configuration.
    /// </summary>
    public class AzureTableStorageApplicationLogsConfig
    {
        /// <summary>
        /// Log level.
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// SAS URL to an Azure table with add/query/delete permissions.
        /// </summary>
        public string SasUrl { get; set; }
    }
}