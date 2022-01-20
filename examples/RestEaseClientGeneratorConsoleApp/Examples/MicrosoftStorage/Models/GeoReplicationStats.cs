using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class GeoReplicationStats
    {
        public string Status { get; set; }

        public DateTime LastSyncTime { get; set; }

        public bool CanFailover { get; set; }
    }
}