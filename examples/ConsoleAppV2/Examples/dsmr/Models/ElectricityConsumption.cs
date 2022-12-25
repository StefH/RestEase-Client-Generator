using System;
using System.Collections.Generic;

namespace ConsoleAppV2.Examples.DSMR.Models
{
    public class ElectricityConsumption
    {
        public int Id { get; set; }

        public DateTime ReadAt { get; set; }

        /// <summary>
        /// Meter Reading electricity delivered to client (Dutch users: low tariff) in 0,001 kWh
        /// </summary>
        public string Delivered1 { get; set; }

        /// <summary>
        /// Meter Reading electricity delivered by client (Dutch users: low tariff) in 0,001 kWh
        /// </summary>
        public string Returned1 { get; set; }

        /// <summary>
        /// Meter Reading electricity delivered to client (normal tariff) in 0,001 kWh
        /// </summary>
        public string Delivered2 { get; set; }

        /// <summary>
        /// Meter Reading electricity delivered by client (normal tariff) in 0,001 kWh
        /// </summary>
        public string Returned2 { get; set; }

        /// <summary>
        /// Actual electricity power delivered (+P) in 1 Watt resolution
        /// </summary>
        public string CurrentlyDelivered { get; set; }

        /// <summary>
        /// Actual electricity power received (-P) in 1 Watt resolution
        /// </summary>
        public string CurrentlyReturned { get; set; }

        /// <summary>
        /// Instantaneous active power L1 (+P) in W resolution
        /// </summary>
        public string PhaseCurrentlyDeliveredL1 { get; set; }

        /// <summary>
        /// Instantaneous active power L2 (+P) in W resolution
        /// </summary>
        public string PhaseCurrentlyDeliveredL2 { get; set; }

        /// <summary>
        /// Instantaneous active power L3 (+P) in W resolution
        /// </summary>
        public string PhaseCurrentlyDeliveredL3 { get; set; }

        /// <summary>
        /// Instantaneous active power L1 (-P) in W resolution
        /// </summary>
        public string PhaseCurrentlyReturnedL1 { get; set; }

        /// <summary>
        /// Instantaneous active power L2 (-P) in W resolution
        /// </summary>
        public string PhaseCurrentlyReturnedL2 { get; set; }

        /// <summary>
        /// Instantaneous active power L3 (-P) in W resolution
        /// </summary>
        public string PhaseCurrentlyReturnedL3 { get; set; }

        /// <summary>
        /// Current voltage for phase L1 (in V)
        /// </summary>
        public string PhaseVoltageL1 { get; set; }

        /// <summary>
        /// Current voltage for phase L2 (in V)
        /// </summary>
        public string PhaseVoltageL2 { get; set; }

        /// <summary>
        /// Current voltage for phase L3 (in V)
        /// </summary>
        public string PhaseVoltageL3 { get; set; }

        /// <summary>
        /// Power/current for phase L1 (in A)
        /// </summary>
        public int PhasePowerCurrentL1 { get; set; }

        /// <summary>
        /// Power/current for phase L2 (in A)
        /// </summary>
        public int PhasePowerCurrentL2 { get; set; }

        /// <summary>
        /// Power/current for phase L3 (in A)
        /// </summary>
        public int PhasePowerCurrentL3 { get; set; }
    }
}