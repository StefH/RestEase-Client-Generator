using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.Infura.Models
{
    public class BlacklistResponse
    {
        public int Version { get; set; }

        public int Tolerance { get; set; }

        public string[] Fuzzylist { get; set; }

        public string[] Whitelist { get; set; }

        public string[] Blacklist { get; set; }
    }
}
