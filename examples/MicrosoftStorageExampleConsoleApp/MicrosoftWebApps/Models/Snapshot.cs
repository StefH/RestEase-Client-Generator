using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// A snapshot of an app.
    /// </summary>
    public class Snapshot : ProxyOnlyResource 
    {
        /// <summary>
        /// Snapshot resource specific properties
        /// </summary>
        public SnapshotProperties Properties { get; set; }

    }
}