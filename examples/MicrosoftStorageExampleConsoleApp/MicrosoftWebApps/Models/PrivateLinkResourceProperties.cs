using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Properties of a private link resource
    /// </summary>
    public class PrivateLinkResourceProperties
    {
        /// <summary>
        /// GroupId of a private link resource
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// RequiredMembers of a private link resource
        /// </summary>
        public string[] RequiredMembers { get; set; }

        /// <summary>
        /// RequiredZoneNames of a private link resource
        /// </summary>
        public string[] RequiredZoneNames { get; set; }
    }
}