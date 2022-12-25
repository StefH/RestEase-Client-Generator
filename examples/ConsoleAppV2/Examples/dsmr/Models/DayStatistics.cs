using System;
using System.Collections.Generic;

namespace ConsoleAppV2.Examples.DSMR.Models
{
    public class DayStatistics
    {
        public int Id { get; set; }

        public DateTime Day { get; set; }

        /// <summary>
        /// The difference between the first and last reading of the day
        /// </summary>
        public string Electricity1 { get; set; }

        /// <summary>
        /// The difference between the first and last reading of the day
        /// </summary>
        public string Electricity2 { get; set; }

        /// <summary>
        /// The difference between the first and last reading of the day
        /// </summary>
        public string Electricity1Returned { get; set; }

        /// <summary>
        /// The difference between the first and last reading of the day
        /// </summary>
        public string Electricity2Returned { get; set; }

        public string Electricity1Cost { get; set; }

        public string Electricity2Cost { get; set; }

        /// <summary>
        /// The difference between the first and last reading of the day
        /// </summary>
        public string Gas { get; set; }

        public string GasCost { get; set; }

        public string LowestTemperature { get; set; }

        public string HighestTemperature { get; set; }

        public string AverageTemperature { get; set; }

        public string FixedCost { get; set; }

        public string TotalCost { get; set; }

        /// <summary>
        /// The first absolute value read at the start of the day
        /// </summary>
        public string Electricity1Reading { get; set; }

        /// <summary>
        /// The first absolute value read at the start of the day
        /// </summary>
        public string Electricity2Reading { get; set; }

        /// <summary>
        /// The first absolute value read at the start of the day
        /// </summary>
        public string Electricity1ReturnedReading { get; set; }

        /// <summary>
        /// The first absolute value read at the start of the day
        /// </summary>
        public string Electricity2ReturnedReading { get; set; }

        /// <summary>
        /// The first absolute value read at the start of the day
        /// </summary>
        public string GasReading { get; set; }
    }
}