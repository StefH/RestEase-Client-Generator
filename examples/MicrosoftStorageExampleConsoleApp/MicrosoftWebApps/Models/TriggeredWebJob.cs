using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Triggered Web Job Information.
    /// </summary>
    public class TriggeredWebJob : ProxyOnlyResource
    {
        /// <summary>
        /// TriggeredWebJob resource specific properties
        /// </summary>
        public TriggeredWebJobProperties Properties { get; set; }

    }
}