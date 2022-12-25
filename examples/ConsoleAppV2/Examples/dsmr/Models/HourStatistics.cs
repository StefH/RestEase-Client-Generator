using System;
using System.Collections.Generic;

namespace ConsoleAppV2.Examples.DSMR.Models
{
    public class HourStatistics
    {
        public int Id { get; set; }

        public DateTime HourStart { get; set; }

        public string Electricity1 { get; set; }

        public string Electricity2 { get; set; }

        public string Electricity1Returned { get; set; }

        public string Electricity2Returned { get; set; }

        public string Gas { get; set; }
    }
}