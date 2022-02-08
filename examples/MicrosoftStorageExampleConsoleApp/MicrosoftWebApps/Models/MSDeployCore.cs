using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// MSDeploy ARM PUT core information
    /// </summary>
    public class MSDeployCore
    {
        /// <summary>
        /// Package URI
        /// </summary>
        public string PackageUri { get; set; }

        /// <summary>
        /// SQL Connection String
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Database Type
        /// </summary>
        public string DbType { get; set; }

        /// <summary>
        /// URI of MSDeploy Parameters file. Must not be set if SetParameters is used.
        /// </summary>
        public string SetParametersXmlFileUri { get; set; }

        /// <summary>
        /// MSDeploy Parameters. Must not be set if SetParametersXmlFileUri is used.
        /// </summary>
        public Dictionary<string, string> SetParameters { get; set; }

        /// <summary>
        /// Controls whether the MSDeploy operation skips the App_Data directory.If set to true, the existing App_Data directory on the destinationwill not be deleted, and any App_Data directory in the source will be ignored.Setting is false by default.
        /// </summary>
        public bool SkipAppData { get; set; }

        /// <summary>
        /// Sets the AppOffline rule while the MSDeploy operation executes.Setting is false by default.
        /// </summary>
        public bool AppOffline { get; set; }
    }
}