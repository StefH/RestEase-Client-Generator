using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.Infura.Models
{
    public class TickerResponse
    {
        public string Base { get; set; }

        public string Quote { get; set; }

        public double Bid { get; set; }

        public double Ask { get; set; }

        public string Exchange { get; set; }

        public double Volume { get; set; }

        public int NumExchanges { get; set; }

        public double TotalVolume { get; set; }

        public int Timestamp { get; set; }
    }
}
