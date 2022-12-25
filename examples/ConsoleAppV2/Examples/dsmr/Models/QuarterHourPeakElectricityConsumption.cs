using System;
using System.Collections.Generic;

namespace ConsoleAppV2.Examples.DSMR.Models
{
    public class QuarterHourPeakElectricityConsumption
    {
        public int Id { get; set; }

        /// <summary>
        /// The timestamp of the first reading used for average calculation
        /// </summary>
        public DateTime ReadAtStart { get; set; }

        /// <summary>
        /// The timestamp of the last reading used for average calculation
        /// </summary>
        public DateTime ReadAtEnd { get; set; }

        /// <summary>
        /// In kW. Calculated by tracking the kWh/15m consumption during the given start/end and multiplying it by 4
        /// </summary>
        public string AverageDelivered { get; set; }
    }
}