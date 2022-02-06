using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Description of a Virtual Network subnet that is useable for private site access.
    /// </summary>
    public class PrivateAccessSubnet
    {
        /// <summary>
        /// The name of the subnet.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The key (ID) of the subnet.
        /// </summary>
        public int Key { get; set; }
    }
}