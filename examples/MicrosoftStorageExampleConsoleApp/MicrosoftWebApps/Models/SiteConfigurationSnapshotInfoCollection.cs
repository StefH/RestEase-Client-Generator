using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of metadata for the app configuration snapshots that can be restored.
    /// </summary>
    public class SiteConfigurationSnapshotInfoCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public SiteConfigurationSnapshotInfo[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}