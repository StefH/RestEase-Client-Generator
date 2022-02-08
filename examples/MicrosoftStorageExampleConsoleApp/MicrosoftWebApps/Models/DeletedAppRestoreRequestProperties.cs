using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// DeletedAppRestoreRequest resource specific properties
    /// </summary>
    public class DeletedAppRestoreRequestProperties
    {
        /// <summary>
        /// ARM resource ID of the deleted app. Example:/subscriptions/{subId}/providers/Microsoft.Web/deletedSites/{deletedSiteId}
        /// </summary>
        public string DeletedSiteId { get; set; }

        /// <summary>
        /// If true, deleted site configuration, in addition to content, will be restored.
        /// </summary>
        public bool RecoverConfiguration { get; set; }

        /// <summary>
        /// Point in time to restore the deleted app from, formatted as a DateTime string. If unspecified, default value is the time that the app was deleted.
        /// </summary>
        public string SnapshotTime { get; set; }

        /// <summary>
        /// If true, the snapshot is retrieved from DRSecondary endpoint.
        /// </summary>
        public bool UseDRSecondary { get; set; }
    }
}