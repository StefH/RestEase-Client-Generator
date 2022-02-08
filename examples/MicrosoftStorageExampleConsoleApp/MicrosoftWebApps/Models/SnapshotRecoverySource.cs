using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Specifies the web app that snapshot contents will be retrieved from.
    /// </summary>
    public class SnapshotRecoverySource
    {
        /// <summary>
        /// Geographical location of the source web app, e.g. SouthEastAsia, SouthCentralUS
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// ARM resource ID of the source app. /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.
        /// </summary>
        public string Id { get; set; }
    }
}