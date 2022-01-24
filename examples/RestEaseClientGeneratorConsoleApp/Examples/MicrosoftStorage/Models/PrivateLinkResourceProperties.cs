using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Properties of a private link resource.
    /// </summary>
    public class PrivateLinkResourceProperties
    {
        /// <summary>
        /// The private link resource group id.
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// The private link resource required member names.
        /// </summary>
        public string[] RequiredMembers { get; set; }

        /// <summary>
        /// The private link resource Private link DNS zone name.
        /// </summary>
        public string[] RequiredZoneNames { get; set; }
    }
}