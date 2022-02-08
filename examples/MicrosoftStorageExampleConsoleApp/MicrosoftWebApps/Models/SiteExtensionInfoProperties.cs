using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// SiteExtensionInfo resource specific properties
    /// </summary>
    public class SiteExtensionInfoProperties
    {
        /// <summary>
        /// Site extension ID.
        /// </summary>
        public string ExtensionId { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// Site extension type.
        /// </summary>
        public string ExtensionType { get; set; }

        /// <summary>
        /// Summary description.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Detailed description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Version information.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Extension URL.
        /// </summary>
        public string ExtensionUrl { get; set; }

        /// <summary>
        /// Project URL.
        /// </summary>
        public string ProjectUrl { get; set; }

        /// <summary>
        /// Icon URL.
        /// </summary>
        public string IconUrl { get; set; }

        /// <summary>
        /// License URL.
        /// </summary>
        public string LicenseUrl { get; set; }

        /// <summary>
        /// Feed URL.
        /// </summary>
        public string FeedUrl { get; set; }

        /// <summary>
        /// List of authors.
        /// </summary>
        public string[] Authors { get; set; }

        /// <summary>
        /// Installer command line parameters.
        /// </summary>
        public string InstallerCommandLineParams { get; set; }

        /// <summary>
        /// Published timestamp.
        /// </summary>
        public DateTime PublishedDateTime { get; set; }

        /// <summary>
        /// Count of downloads.
        /// </summary>
        public int DownloadCount { get; set; }

        /// <summary>
        /// true if the local version is the latest version; false otherwise.
        /// </summary>
        public bool LocalIsLatestVersion { get; set; }

        /// <summary>
        /// Local path.
        /// </summary>
        public string LocalPath { get; set; }

        /// <summary>
        /// Installed timestamp.
        /// </summary>
        public DateTime InstalledDateTime { get; set; }

        /// <summary>
        /// Provisioning state.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Site Extension comment.
        /// </summary>
        public string Comment { get; set; }
    }
}