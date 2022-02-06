using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Names for connection strings, application settings, and external Azure storage account configurationidentifiers to be marked as sticky to the deployment slot and not moved during a swap operation.This is valid for all deployment slots in an app.
    /// </summary>
    public class SlotConfigNames
    {
        /// <summary>
        /// List of connection string names.
        /// </summary>
        public string[] ConnectionStringNames { get; set; }

        /// <summary>
        /// List of application settings names.
        /// </summary>
        public string[] AppSettingNames { get; set; }

        /// <summary>
        /// List of external Azure storage account identifiers.
        /// </summary>
        public string[] AzureStorageConfigNames { get; set; }
    }
}