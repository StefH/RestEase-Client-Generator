using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    public class ContainerNetworkInterfaceStatistics
    {
        public long RxBytes { get; set; }

        public long RxPackets { get; set; }

        public long RxErrors { get; set; }

        public long RxDropped { get; set; }

        public long TxBytes { get; set; }

        public long TxPackets { get; set; }

        public long TxErrors { get; set; }

        public long TxDropped { get; set; }
    }
}