using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// A snapshot of a web app configuration.
    /// </summary>
    public class SiteConfigurationSnapshotInfo : ProxyOnlyResource
    {
        /// <summary>
        /// SiteConfigurationSnapshotInfo resource specific properties
        /// </summary>
        public SiteConfigurationSnapshotInfoProperties Properties { get; set; }

    }
}