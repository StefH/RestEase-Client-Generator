using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The state of a private link connection
    /// </summary>
    public class PrivateLinkConnectionState
    {
        /// <summary>
        /// Status of a private link connection
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Description of a private link connection
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ActionsRequired for a private link connection
        /// </summary>
        public string ActionsRequired { get; set; }
    }
}