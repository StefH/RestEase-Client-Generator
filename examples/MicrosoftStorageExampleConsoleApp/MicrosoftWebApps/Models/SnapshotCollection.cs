using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Collection of snapshots which can be used to revert an app to a previous time.
    /// </summary>
    public class SnapshotCollection
    {
        /// <summary>
        /// Collection of resources.
        /// </summary>
        public Snapshot[] Value { get; set; }

        /// <summary>
        /// Link to next page of resources.
        /// </summary>
        public string NextLink { get; set; }
    }
}