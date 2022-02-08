using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// PrivateAccess resource specific properties
    /// </summary>
    public class PrivateAccessProperties
    {
        /// <summary>
        /// Whether private access is enabled or not.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The Virtual Networks (and subnets) allowed to access the site privately.
        /// </summary>
        public PrivateAccessVirtualNetwork[] VirtualNetworks { get; set; }
    }
}