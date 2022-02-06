using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// DeletedSite resource specific properties
    /// </summary>
    public class DeletedSiteProperties
    {
        /// <summary>
        /// Numeric id for the deleted site
        /// </summary>
        public int DeletedSiteId { get; set; }

        /// <summary>
        /// Time in UTC when the app was deleted.
        /// </summary>
        public string DeletedTimestamp { get; set; }

        /// <summary>
        /// Subscription containing the deleted site
        /// </summary>
        public string Subscription { get; set; }

        /// <summary>
        /// ResourceGroup that contained the deleted site
        /// </summary>
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Name of the deleted site
        /// </summary>
        public string DeletedSiteName { get; set; }

        /// <summary>
        /// Slot of the deleted site
        /// </summary>
        public string Slot { get; set; }

        /// <summary>
        /// Kind of site that was deleted
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Geo Region of the deleted site
        /// </summary>
        public string GeoRegionName { get; set; }
    }
}