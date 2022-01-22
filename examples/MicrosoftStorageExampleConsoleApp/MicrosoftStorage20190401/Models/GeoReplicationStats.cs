using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    public class GeoReplicationStats
    {
        public string Status { get; set; }

        public DateTime LastSyncTime { get; set; }

        public bool CanFailover { get; set; }
    }
}