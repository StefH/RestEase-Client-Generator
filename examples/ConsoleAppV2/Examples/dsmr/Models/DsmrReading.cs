using System;
using System.Collections.Generic;

namespace ConsoleAppV2.Examples.DSMR.Models
{
    public class DsmrReading
    {
        public int Id { get; set; }

        /// <summary>
        /// Timestamp indicating when the reading was taken, according to the smart meter
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Meter position stating electricity delivered (Dutch users: low tariff) in kWh
        /// </summary>
        public string ElectricityDelivered1 { get; set; }

        /// <summary>
        /// Meter position stating electricity returned (Dutch users: low tariff) in kWh
        /// </summary>
        public string ElectricityReturned1 { get; set; }

        /// <summary>
        /// Meter position stating electricity delivered (normal tariff) in kWh
        /// </summary>
        public string ElectricityDelivered2 { get; set; }

        /// <summary>
        /// Meter position stating electricity returned (normal tariff) in kWh
        /// </summary>
        public string ElectricityReturned2 { get; set; }

        /// <summary>
        /// Current electricity delivered in kW
        /// </summary>
        public string ElectricityCurrentlyDelivered { get; set; }

        /// <summary>
        /// Current electricity returned in kW
        /// </summary>
        public string ElectricityCurrentlyReturned { get; set; }

        /// <summary>
        /// Current electricity used by phase L1 (in kW)
        /// </summary>
        public string PhaseCurrentlyDeliveredL1 { get; set; }

        /// <summary>
        /// Current electricity used by phase L2 (in kW)
        /// </summary>
        public string PhaseCurrentlyDeliveredL2 { get; set; }

        /// <summary>
        /// Current electricity used by phase L3 (in kW)
        /// </summary>
        public string PhaseCurrentlyDeliveredL3 { get; set; }

        /// <summary>
        /// Last timestamp read from the extra device connected (gas meter)
        /// </summary>
        public DateTime ExtraDeviceTimestamp { get; set; }

        /// <summary>
        /// Last value read from the extra device connected (gas meter)
        /// </summary>
        public string ExtraDeviceDelivered { get; set; }

        /// <summary>
        /// Current electricity returned by phase L1 (in kW)
        /// </summary>
        public string PhaseCurrentlyReturnedL1 { get; set; }

        /// <summary>
        /// Current electricity returned by phase L2 (in kW)
        /// </summary>
        public string PhaseCurrentlyReturnedL2 { get; set; }

        /// <summary>
        /// Current electricity returned by phase L3 (in kW)
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