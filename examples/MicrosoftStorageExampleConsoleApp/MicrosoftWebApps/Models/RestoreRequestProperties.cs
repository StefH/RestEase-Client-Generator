using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// RestoreRequest resource specific properties
    /// </summary>
    public class RestoreRequestProperties
    {
        /// <summary>
        /// SAS URL to the container.
        /// </summary>
        public string StorageAccountUrl { get; set; }

        /// <summary>
        /// Name of a blob which contains the backup.
        /// </summary>
        public string BlobName { get; set; }

        /// <summary>
        /// true if the restore operation can overwrite target app; otherwise, false. true is needed if trying to restore over an existing app.
        /// </summary>
        public bool Overwrite { get; set; }

        /// <summary>
        /// Name of an app.
        /// </summary>
        public string SiteName { get; set; }

        /// <summary>
        /// Collection of databases which should be restored. This list has to match the list of databases included in the backup.
        /// </summary>
        public DatabaseBackupSetting[] Databases { get; set; }

        /// <summary>
        /// Changes a logic when restoring an app with custom domains. true to remove custom domains automatically. If false, custom domains are added to the app's object when it is being restored, but that might fail due to conflicts during the operation.
        /// </summary>
        public bool IgnoreConflictingHostNames { get; set; }

        /// <summary>
        /// Ignore the databases and only restore the site content
        /// </summary>
        public bool IgnoreDatabases { get; set; }

        /// <summary>
        /// Specify app service plan that will own restored site.
        /// </summary>
        public string AppServicePlan { get; set; }

        /// <summary>
        /// Operation type.
        /// </summary>
        public string OperationType { get; set; }

        /// <summary>
        /// true if SiteConfig.ConnectionStrings should be set in new app; otherwise, false.
        /// </summary>
        public bool AdjustConnectionStrings { get; set; }

        /// <summary>
        /// App Service Environment name, if needed (only when restoring an app to an App Service Environment).
        /// </summary>
        public string HostingEnvironment { get; set; }
    }
}