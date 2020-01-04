using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.Infura.Models
{
    public class TickerFullResponse
    {
        public string Base { get; set; }

        public string Quote { get; set; }

        public object[] Tickers { get; set; }
    }
}
