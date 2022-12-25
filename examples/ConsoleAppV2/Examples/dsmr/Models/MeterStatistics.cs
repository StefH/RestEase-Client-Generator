using System;
using System.Collections.Generic;

namespace ConsoleAppV2.Examples.DSMR.Models
{
    public class MeterStatistics
    {
        public int Id { get; set; }

        /// <summary>
        /// Timestamp indicating when the reading was taken
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// DSMR version
        /// </summary>
        public string DsmrVersion { get; set; }

        /// <summary>
        /// Tariff indicator electricity. The tariff indicator can be used to switch tariff  dependent loads e.g boilers. This is responsibility of the P1 user.
        /// </summary>
        public int ElectricityTariff { get; set; }

        /// <summary>
        /// Number of power failures in any phase
        /// </summary>
        public int PowerFailureCount { get; set; }

        /// <summary>
        /// Number of long power failures in any phase
        /// </summary>
        public int LongPowerFailureCount { get; set; }

        /// <summary>
        /// Number of voltage sags/dips in phase L1
        /// </summary>
        public int VoltageSagCountL1 { get; set; }

        /// <summary>
        /// Number of voltage sags/dips in phase L2 (polyphase meters only)
        /// </summary>
        public int VoltageSagCountL2 { get; set; }

        /// <summary>
        /// Number of voltage sags/dips in phase L3 (polyphase meters only)
        /// </summary>
        public int VoltageSagCountL3 { get; set; }

        /// <summary>
        /// Number of voltage swells in phase L1
        /// </summary>
        public int VoltageSwellCountL1 { get; set; }

        /// <summary>
        /// Number of voltage swells in phase L2 (polyphase meters only)
        /// </summary>
        public int VoltageSwellCountL2 { get; set; }

        /// <summary>
        /// Number of voltage swells in phase L3 (polyphase meters only)
        /// </summary>
        public int VoltageSwellCountL3 { get; set; }

        /// <summary>
        /// Number of rejected telegrams due to invalid CRC checksum
        /// </summary>
        public int RejectedTelegrams { get; set; }

        /// <summary>
        /// The latest telegram succesfully read. Please note that only the latest telegram is saved here and will be overwritten each time.
        /// </summary>
        public string LatestTelegram { get; set; }
    }
}